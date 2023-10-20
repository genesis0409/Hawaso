﻿using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using VisualAcademy.Models.Uploads;

namespace Hawaso.Pages.Uploads;

public partial class Details
{
    #region Parameters
    [Parameter]
    public int Id { get; set; } 
    #endregion

    [Inject]
    public IUploadRepository UploadRepositoryAsyncReference { get; set; }

    protected Upload model = new Upload();

    protected string content = "";

    protected override async Task OnInitializedAsync()
    {
        model = await UploadRepositoryAsyncReference.GetByIdAsync(Id);
        content = Dul.HtmlUtility.EncodeWithTabAndSpace(model.Content);
    }
}
