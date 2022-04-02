﻿using InvoiceXpress.Payloads;
using InvoiceXpress.Rest;
using RestSharp;

namespace InvoiceXpress;

public partial class InvoiceXpressClient
{
    /// <summary />
    public async Task<ApiResult<Estimate>> EstimateCreateAsync( EstimateData estimate )
    {
        var entityName = EstimateEntity.ToEntityName( estimate.Type );
        var payload = new EstimateDataPayload() { Estimate = estimate };

        var req = new RestRequest( $"/{ entityName }.json" )
            .AddJsonBody( payload );

        var resp = await _rest.PostAsync<EstimatePayload>( req );

        if ( resp == null )
            throw new InvalidOperationException();

        return Result( resp.Estimate );
    }


    /// <summary />
    public async Task<ApiResult<Estimate>> EstimateGetAsync( EstimateType type, int estimateId )
    {
        var entityName = EstimateEntity.ToEntityName( type );
        var req = new RestRequest( $"/{ entityName }/{ estimateId }.json" );

        var resp = await _rest.GetAsync<EstimatePayload>( req );

        if ( resp == null )
            throw new InvalidOperationException();

        return Result( resp.Estimate );
    }


    /// <summary />
    public async Task<ApiResult> EstimateUpdateAsync( EstimateData estimate )
    {
        var entityName = EstimateEntity.ToEntityName( estimate.Type );
        var payload = new EstimateDataPayload() { Estimate = estimate };

        var req = new RestRequest( $"/{ entityName }/{ estimate.Id }.json" )
            .AddJsonBody( payload );

        await _rest.PutAsync( req );

        return new ApiResult();
    }


    /// <summary />
    public async Task<ApiResult> EstimateStateChangeAsync( EstimateType type, int estimateId, EstimateStateChange change )
    {
        var entityName = EstimateEntity.ToEntityName( type );
        var payload = new EstimateStateChangePayload()
        {
            EstimateType = type,
            Change = change,
        };

        var req = new RestRequest( $"/{ entityName }/{ estimateId }/change-state.json" )
            .AddJsonBody( payload );

        var resp = await _rest.PutAsync( req );

        return new ApiResult();
    }


    /// <summary />
    public async Task<ApiResult<List<Estimate>>> EstimateListAsync( int page, int pageSize = 20 )
    {
        var req = new RestRequest( "/estimates.json" )
            .AddQueryParameter( "page", page )
            .AddQueryParameter( "per_page", pageSize );

        var resp = await _rest.GetAsync<EstimateListPayload>( req );

        return Result( resp!.Estimates );
    }


    /// <summary />
    public async Task<ApiResult> EstimateSendByEmailAsync()
    {
        await Task.Delay( 0 );
        throw new NotImplementedException();
    }


    /// <summary />
    public async Task<ApiResult> EstimatePdfGenerateAsync()
    {
        await Task.Delay( 0 );
        throw new NotImplementedException();
    }
}
