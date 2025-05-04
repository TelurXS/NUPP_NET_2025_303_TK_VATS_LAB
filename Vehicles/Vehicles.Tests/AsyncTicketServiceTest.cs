using FluentAssertions;
using Vehicles.Common.Entities;
using Vehicles.Common.Infrastructure.Async;

namespace Vehicles.Tests;

public class AsyncTicketServiceTest
{
    private const string FILE_PATH = "tickets.json";
    
    private readonly AsyncTicketService _service;
    
    public AsyncTicketServiceTest()
    {
        _service = new();
    }
    
    [Fact]
    public async Task Create_NotExistingValue_ReturnsTrue()
    {
        var ticket = Ticket.Create();

        var result = await _service.CreateAsync(ticket);
        
        result.Should().BeTrue();
    }
    
    [Fact]
    public async Task Create_ExistingValue_ReturnsFalse()
    {
        var ticket = Ticket.Create();

        await _service.CreateAsync(ticket);

        var result = await _service.CreateAsync(ticket);
        
        result.Should().Be(false);
    }
    
    [Fact]
    public async Task Find_NotExistingValue_ReturnsNull()
    {
        var id =  Guid.CreateVersion7(); 
        
        var result = await _service.ReadAsync(id);
        
        result.Should().BeNull();
    }
    
    [Fact]
    public async Task Find_ExistingValue_ReturnsEntity()
    {
        var ticket = Ticket.Create();
        
        await _service.CreateAsync(ticket);

        var result = await _service.ReadAsync(ticket.Id);
            
        result.Should().NotBeNull();
    }
    
    [Fact]
    public async Task Update_NotExistingValue_ReturnsFalse()
    {
        var ticket = Ticket.Create();
        
        var result = await _service.UpdateAsync(ticket);

        result.Should().BeFalse();
    }
    
    [Fact]
    public async Task Update_ExistingValue_ShouldStoreCopy()
    {
        var price = 40;
        var ticket = Ticket.Create();
        
        await _service.CreateAsync(ticket);
        
        ticket.UpdatePrice(price);

        var entry = await _service.ReadAsync(ticket.Id);

        entry.Should().NotBeNull();
        entry.Price.Should().NotBe(price);
    }
    
    [Fact]
    public async Task Update_ExistingValue_ReturnsTrueAndUpdates()
    {
        var price = 40;
        var ticket = Ticket.Create();
        
        await _service.CreateAsync(ticket);
        
        ticket.UpdatePrice(price);

        var result = await _service.UpdateAsync(ticket);

        result.Should().Be(true);
        
        var entry = await _service.ReadAsync(ticket.Id);

        entry.Should().NotBeNull();
        entry.Price.Should().Be(price);
    }
    
    [Fact]
    public async Task Delete_NotExistingValue_ReturnsFalse()
    {
        var ticket = Ticket.Create();
        
        var result = await _service.RemoveAsync(ticket);

        result.Should().BeFalse();
    }
    
    [Fact]
    public async Task Delete_ExistingValue_ReturnsTrue()
    {
        var ticket = Ticket.Create();
        
        await _service.CreateAsync(ticket);

        var result = await _service.RemoveAsync(ticket);

        result.Should().BeTrue();
    }

    [Fact]
    public async Task Save_InFile_ShouldBeSaved()
    {
        await _service.CreateAsync(Ticket.Create());
        await _service.CreateAsync(Ticket.Create());
        await _service.CreateAsync(Ticket.Create());

        await _service.SaveAsync(FILE_PATH);
        
        File.Exists(FILE_PATH).Should().BeTrue();
    }
    
    [Fact]
    public async Task Load_FromFile_ShouldBeLoaded()
    {
        await _service.LoadAsync(FILE_PATH);
        
        _service.Count().Should().BeGreaterThan(0);
    }
}