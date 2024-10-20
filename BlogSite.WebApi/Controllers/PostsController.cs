using BlogSite.Models.Dtos.Posts.Requests;
using BlogSite.Service.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
// Injection'ı primary constructor ile yaptık.
public class PostsController(IPostService _postService) : ControllerBase
{
  [HttpGet("getall")]
  public async Task<IActionResult> GetAllAsync()
  {
    var result = await _postService.GetAllAsync();
    return Ok(result);
  }

  [HttpPost("add")]
  public async Task<IActionResult> AddAsync([FromBody]CreatePostRequest dto)
  {
    var result = await _postService.AddAsync(dto);
    return Ok(result);
  }

  [HttpGet("getbyid/{id}")]
  public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
  {
    var result = await _postService.GetByIdAsync(id);
    return Ok(result);
  }

  [HttpDelete("delete")]
  public async Task<IActionResult> DeleteAsync([FromQuery] Guid id)
  {
    var result = await _postService.RemoveAsync(id);
    return Ok(result);
  }

  [HttpPut("update")]
  public async Task<IActionResult> UpdateAsync([FromBody] UpdatePostRequest dto)
  {
    var result = await _postService.UpdateAsync(dto);
    return Ok(result);
  }
}