﻿using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;

namespace InvoiceXpress.Cli;

/// <summary />
[Command( "create", Description = "Create a sequence" )]
public class SequenceCreateCommand
{
    /// <summary />
    [Argument( 0, Description = "Sequence record, in JSON file" )]
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
        var seq = jss.Deserialize<SequenceData>( json );


        /*
         * 
         */
        var res = await api.SequenceCreateAsync( seq );

        if ( res.IsSuccessful == false )
            return console.WriteError( res );

        Console.Write( res.Result!.Id );

        return 0;
    }
}
