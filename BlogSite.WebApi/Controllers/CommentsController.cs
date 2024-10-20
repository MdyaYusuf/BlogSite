﻿using BlogSite.Models.Dtos.Comments.Requests;
using BlogSite.Service.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentsController(ICommentService _commentService) : ControllerBase
{
  [HttpGet("getall")]
  public async Task<IActionResult> GetAllAsync()
  {
    var result = await _commentService.GetAllAsync();
    return Ok(result);
  }

  [HttpPost("add")]
  public async Task<IActionResult> AddAsync([FromBody] CreateCommentRequest dto)
  {
    var result = await _commentService.AddAsync(dto);
    return Ok(result);
  }

  [HttpGet("getbyid/{id}")]
  public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
  {
    var result = await _commentService.GetByIdAsync(id);
    return Ok(result);
  }

  [HttpDelete("delete")]
  public async Task<IActionResult> DeleteAsync([FromQuery] Guid id)
  {
    var result = await _commentService.RemoveAsync(id);
    return Ok(result);
  }

  [HttpPut("update")]
  public async Task<IActionResult> UpdateAsync([FromBody] UpdateCommentRequest dto)
  {
    var result = await _commentService.UpdateAsync(dto);
    return Ok(result);
  }
}
