﻿using Discount.Grpc.Data;
using Discount.Grpc.Models;
using Grpc.Core;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Services
{
    public class DiscountService(DiscountContext dbContext, ILogger<DiscountService> logger) 
        : DiscountProtoService.DiscountProtoServiceBase
    {
        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var coupon = await dbContext
                .Coupons
                .FirstOrDefaultAsync(x => x.ProductName == request.ProductName);

            coupon ??= new Coupon { ProductName = "No discount", Amount = 0, Description = "No Desc" };

            var couponModel = coupon.Adapt<CouponModel>();

            logger.LogInformation($"Data retrieved for {coupon.ProductName}");
            return couponModel;
        }
        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            var coupon = request.Coupon.Adapt<Coupon>();
            if (coupon == null)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request object"));
            }
            dbContext.Coupons.Add(coupon);
            await dbContext.SaveChangesAsync();

            var couponModel = coupon.Adapt<CouponModel>();

            logger.LogInformation($"Data successfully created for {coupon.ProductName}");
            return couponModel;
        }
        public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            var coupon = request.Coupon.Adapt<Coupon>();
            if (coupon == null)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request object"));
            }
            dbContext.Coupons.Update(coupon);
            await dbContext.SaveChangesAsync();

            var couponModel = coupon.Adapt<CouponModel>();

            logger.LogInformation($"Data successfully updated for {coupon.ProductName}");
            return couponModel;
        }
        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            var coupon = await dbContext.Coupons.FirstOrDefaultAsync(x=>x.ProductName==request.ProductName);

            if (coupon == null)
            {
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request object"));
            }

            dbContext.Coupons.Remove(coupon);
            await dbContext.SaveChangesAsync();

            logger.LogInformation($"Data successfully deleted for {coupon.ProductName}");
            return new DeleteDiscountResponse { Success = true };
        }
    }
}
