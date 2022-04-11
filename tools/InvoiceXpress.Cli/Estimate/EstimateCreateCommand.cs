﻿using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "create", Description = "Create an estimate" )]
public class EstimateCreateCommand
{
    /// <summary />
    [Argument( 0, Description = "Estimate record, in JSON file" )]
    [Required]
    [FileExists]
    public string? FilePath { get; set; }


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, IConsole console )
    {
        /*
         * 
         */
        var json = await File.ReadAllTextAsync( this.FilePath! );
        var estimate = JsonSerializer.Deserialize<EstimateData>( json )!;


        /*
         * 
         */
        var res = await api.EstimateCreateAsync( estimate );

        if ( res.IsSuccessful == false )
            return console.WriteError( res );

        Console.WriteLine( "Estimate Id: {0}", res.Result!.Id );

        return 0;
    }
}
