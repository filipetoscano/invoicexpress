﻿using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "get", Description = "Gets an item record" )]
public class ItemDetailCommand
{
    /// <summary />
    [Argument( 0, Description = "Item identifier" )]
    [Required]
    public int ItemId { get; set; }


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, IConsole console )
    {
        var res = await api.ItemGetAsync( this.ItemId );

        if ( res.IsSuccessful == false )
            return console.WriteError( res );


        /*
         * 
         */
        var json = JsonSerializer.Serialize( res.Result!, new JsonSerializerOptions() { WriteIndented = true } );
        Console.WriteLine( json );

        return 0;
    }
}
