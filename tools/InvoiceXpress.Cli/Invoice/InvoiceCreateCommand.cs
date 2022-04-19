﻿using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "create", Description = "Create an invoice" )]
public class InvoiceCreateCommand
{
    /// <summary />
    [Argument( 0, Description = "Invoice record, in JSON file" )]
    [Required]
    [FileExists]
    public string? FilePath { get; set; }


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, Jsonizer jss, IConsole console )
    {
        /*
         * 
         */
        var json = await File.ReadAllTextAsync( this.FilePath! );
        var invoice = jss.Deserialize<InvoiceData>( json );


        /*
         * 
         */
        var res = await api.InvoiceCreateAsync( invoice );

        if ( res.IsSuccessful == false )
            return console.WriteError( res );

        Console.WriteLine( res.Result!.Id );

        return 0;
    }
}
