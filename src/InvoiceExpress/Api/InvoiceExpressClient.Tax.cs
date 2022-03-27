﻿using InvoiceExpress.Payloads;
using RestSharp;

namespace InvoiceExpress;

/// <summary />
public partial class InvoiceExpressClient
{
    /// <summary />
    public async Task<ApiResult<List<Tax>>> TaxListAsync()
    {
        var req = new RestRequest( "/taxes.json" );

        var resp = await _rest.GetAsync<TaxListPayload>( req );

        return Result( resp!.Taxes );
    }


    /// <summary />
    public async Task<ApiResult<Tax>> TaxCreateAsync( Tax item )
    {
        var req = new RestRequest( "/taxes.json" )
            .AddJsonBody( new TaxPayload() { Tax = item }, "application/json" );

        var resp = await _rest.PostAsync<TaxPayload>( req );

        return Result( resp!.Tax );
    }


    /// <summary />
    public async Task<ApiResult<Tax>> TaxGetAsync( int taxId )
    {
        var req = new RestRequest( $"/taxes/{ taxId }.json" );

        var resp = await _rest.GetAsync<TaxPayload>( req );

        return Result( resp!.Tax );
    }


    /// <summary />
    public async Task<ApiResult<Tax>> TaxUpdateAsync( Tax tax )
    {
        await Task.Delay( 0 );

        throw new NotImplementedException();
    }


    /// <summary />
    public async Task<ApiResult> TaxDeleteAsync( int taxId )
    {
        await Task.Delay( 0 );

        throw new NotImplementedException();
    }
}
