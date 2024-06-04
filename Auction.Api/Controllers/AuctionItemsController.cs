using System.Net.Mime;
using Auction.Application.AuctionItems.Commands.AddAuctionItem;
using Auction.Application.AuctionItems.Commands.DeleteAuctionItem;
using Auction.Application.AuctionItems.Commands.UpdateAuctionItem;
using Auction.Application.AuctionItems.Queries.GetAllAuctionItems;
using Auction.Application.AuctionItems.Queries.GetAuctionItem;
using Auction.Application.AuctionItems.Queries.GetAuctionItemsByBidder;
using Auction.Application.AuctionItems.Queries.GetAuctionItemsBySeller;
using Auction.Application.Dtos;
using AuctionDomain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApi.Controllers;

[Route("[controller]/[action]")]
[ApiController]
[Authorize]
public class AuctionItemsController(ISender mediator) : ControllerBase
{
    [HttpPost]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(AuctionItem), StatusCodes.Status200OK)]
    public async Task<IActionResult> AddAuctionItem([FromBody] AddAuctionItemCommand command)
    {
        var auctionItem = await mediator.Send(command);
        return Ok(auctionItem);
    }

    [HttpPut]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(AuctionItem), StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateAuctionItem([FromBody] UpdateAuctionItemCommand command)
    {
        var updated = await mediator.Send(command);
        return Ok(updated);
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteAuctionItem(int id)
    {
        var command = new DeleteAuctionItemCommand(id);
        await mediator.Send(command);
        return NoContent();
    }

    [HttpGet("{id:int}")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(AuctionItemDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAuctionItemById(int id)
    {
        var query = new GetAuctionItemQuery(id);
        var auctionItem = await mediator.Send(query);
        return Ok(auctionItem);
    }

    [HttpGet]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(IEnumerable<AuctionItemDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAuctionItems()
    {
        var query = new GetAllAuctionItemsQuery();
        var auctionItems = await mediator.Send(query);
        return Ok(auctionItems);
    }

    [HttpGet("{sellerId:int}")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(IEnumerable<AuctionItemDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAuctionItemsBySellerId(int sellerId)
    {
        var query = new GetAuctionItemsBySellerQuery(sellerId);
        var auctionItems = await mediator.Send(query);
        return Ok(auctionItems);
    }

    [HttpGet("{bidderId:int}")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(IEnumerable<AuctionItemDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAuctionItemsByBidderId(int bidderId)
    {
        var query = new GetAuctionItemsByBidderQuery(bidderId);
        var auctionItems = await mediator.Send(query);
        return Ok(auctionItems);
    }
}
