using Amazon.S3;
using Amazon.S3.Util;
using Microsoft.AspNetCore.Mvc;

namespace S3.Demo.API.Controllers
{
    [Route("api/buckets")]
    [ApiController]
    public class BucketsController : ControllerBase
    {
        private readonly IAmazonS3 _s3Client;

        public BucketsController(IAmazonS3 s3Client)
        {
            _s3Client = s3Client;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateBucket(string bucketName)
        {
            bool bucketExists = await AmazonS3Util.DoesS3BucketExistV2Async(_s3Client, bucketName);
            if (bucketExists) return BadRequest($"Bucket {bucketName} already exists.");

            try
            {
                var response = await _s3Client.PutBucketAsync(bucketName);
                return Ok($"Bucket '{bucketName}' created successfully.");
            }
            catch (AmazonS3Exception ex)
            {
                return BadRequest($"Error creating bucket '{bucketName}': {ex.Message}");
            }
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllBuckets()
        {
            try
            {
                var response = await _s3Client.ListBucketsAsync();
                var buckets = response.Buckets.Select(b => { return b.BucketName; });
                return Ok(buckets);
            }
            catch (AmazonS3Exception ex)
            {
                return BadRequest($"Error listing buckets: {ex.Message}");
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteBucket(string bucketName)
        {
            bool bucketExists = await AmazonS3Util.DoesS3BucketExistV2Async(_s3Client, bucketName);
            if (!bucketExists) return NotFound($"Bucket {bucketName} does not exist.");

            try
            {
                var response = await _s3Client.DeleteBucketAsync(bucketName);
                return Ok($"Bucket '{bucketName}' deleted successfully.");
            }
            catch (AmazonS3Exception ex)
            {
                return BadRequest($"Error deleting bucket '{bucketName}': {ex.Message}");
            }
        }
    }
}
