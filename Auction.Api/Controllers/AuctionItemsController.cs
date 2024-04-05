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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApi.Controllers;

[Route("[controller]/[action]")]
[ApiController]
public class AuctionItemsController(ISender mediator) : ControllerBase
{
    [HttpGet]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(IEnumerable<AuctionItemDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAuctionItems([FromQuery]GetAllAuctionItemsQuery query)
    {
        var auctionItems = await mediator.Send(query);
        return Ok(auctionItems);
    }
    
    [HttpGet]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(IEnumerable<AuctionItemDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAuctionItemBySellerId([FromQuery]GetAuctionItemsBySellerQuery query)
    {
        var auctionItems = await mediator.Send(query);
        return Ok(auctionItems);
    }
    
    [HttpGet]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(AuctionItemDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAuctionItemById([FromQuery]GetAuctionItemQuery query)
    {
        var auctionItem = await mediator.Send(query);
        return Ok(auctionItem);
    }    
    
    [HttpGet]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(IEnumerable<AuctionItemDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAuctionItemByBidder([FromQuery]GetAuctionItemsByBidderQuery query)
    {
        var auctionItems = await mediator.Send(query);
        return Ok(auctionItems);
    }        

    [HttpPost]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(AuctionItem), StatusCodes.Status200OK)]
    public async Task<IActionResult> AddAuctionItem([FromBody]AddAuctionItemCommand command)
    {
        var auctionItem = await mediator.Send(command);
        return Ok(auctionItem);
    }    
    
    [HttpPut]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(AuctionItem), StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateAuctionItem([FromBody]UpdateAuctionItemCommand command)
    {
        var updated = await mediator.Send(command);
        return Ok(updated);
    }
    
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteAuctionItem([FromBody]DeleteAuctionItemCommand command)
    {
        await mediator.Send(command);
        return NoContent();
    }
}