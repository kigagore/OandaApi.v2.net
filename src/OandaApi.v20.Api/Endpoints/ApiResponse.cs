using System;
using System.Net;

namespace OandaApi.v20.Api.Endpoints
{
    public sealed class ApiResponse<T> where T: class
    {
        private ApiResponse()
        {
        }
        
        public bool IsSuccess { get; private set; }

        public HttpStatusCode StatusCode { get; private set; }
        
        public ApiError Error { get; private set; }
        
        public T SuccessResponse { get; private set; }

        public static ApiResponse<TP> CreateSuccessResponse<TP>(TP responseObject, HttpStatusCode statusCode) where TP: class
        {
            return new ApiResponse<TP> { IsSuccess = true, StatusCode = statusCode, SuccessResponse = responseObject };
        }
        
        public static ApiResponse<TP> CreateSuccessResponse<TP>(TP responseObject) where TP: class
        {
            return CreateSuccessResponse(responseObject, HttpStatusCode.OK);
        }
        
        public static ApiResponse<TP> CreateErrorResponse<TP>(ApiError error, HttpStatusCode statusCode) where TP: class
        {
            return new ApiResponse<TP> { IsSuccess = false, StatusCode = statusCode, Error = error };
        } 
    }
}