﻿using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "get", Description = "Gets a sequence record" )]
public class SequenceDetailCommand
{
    /// <summary />
    [Argument( 0, Description = "Sequence identifier" )]
    [Required]
    public int SequenceId { get; set; }


    /// <summary />
    private async Task<int> OnExecuteAsync( InvoiceXpressClient api, IConsole console )
    {
        var res = await api.SequenceGetAsync( this.SequenceId );

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
