﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DotNetCore.CAP.Dashboard.Pages
{
    
    #line 2 "..\..\Dashboard\Pages\PublishedPage.cshtml"
    using System;
    
    #line default
    #line hidden
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    #line 4 "..\..\Dashboard\Pages\PublishedPage.cshtml"
    using DotNetCore.CAP.Dashboard;
    
    #line default
    #line hidden
    
    #line 6 "..\..\Dashboard\Pages\PublishedPage.cshtml"
    using DotNetCore.CAP.Dashboard.Monitoring;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Dashboard\Pages\PublishedPage.cshtml"
    using DotNetCore.CAP.Dashboard.Pages;
    
    #line default
    #line hidden
    
    #line 7 "..\..\Dashboard\Pages\PublishedPage.cshtml"
    using DotNetCore.CAP.Dashboard.Resources;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Dashboard\Pages\PublishedPage.cshtml"
    using DotNetCore.CAP.Models;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    internal partial class PublishedPage : RazorPage
    {
#line hidden

        public override void Execute()
        {


WriteLiteral("\r\n");









            
            #line 9 "..\..\Dashboard\Pages\PublishedPage.cshtml"
  
    Layout = new LayoutPage(Strings.SucceededMessagesPage_Title);

    int from, perPage;

    int.TryParse(Query("from"), out from);
    int.TryParse(Query("count"), out perPage);
    string name = Query("name");
    string content = Query("content");

    var monitor = Storage.GetMonitoringApi();
    var pager = new Pager(from, perPage, GetTotal(monitor));
    var total = 0;
    var queryDto = new MessageQueryDto
    {
        MessageType = MessageType.Publish,
        Name = name,
        Content = content,
        StatusName = StatusName,
        CurrentPage =  pager.CurrentPage - 1,
        PageSize = pager.RecordsPerPage
    };
    var succeededMessages = monitor.Messages(queryDto);


            
            #line default
            #line hidden
WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-md-3\">\r\n        ");


            
            #line 36 "..\..\Dashboard\Pages\PublishedPage.cshtml"
   Write(Html.JobsSidebar(MessageType.Publish));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n    <div class=\"col-md-9\">\r\n        <h1 class=\"page-header\">");


            
            #line 39 "..\..\Dashboard\Pages\PublishedPage.cshtml"
                           Write(Strings.SucceededMessagesPage_Title);

            
            #line default
            #line hidden
WriteLiteral("</h1>\r\n\r\n");


            
            #line 41 "..\..\Dashboard\Pages\PublishedPage.cshtml"
         if (succeededMessages.Count == 0)
        {

            
            #line default
            #line hidden
WriteLiteral("            <div class=\"alert alert-info\">\r\n                ");


            
            #line 44 "..\..\Dashboard\Pages\PublishedPage.cshtml"
           Write(Strings.SucceededJobsPage_NoJobs);

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n");


            
            #line 46 "..\..\Dashboard\Pages\PublishedPage.cshtml"
        }
        else
        {

            
            #line default
            #line hidden
WriteLiteral(@"            <div class=""js-jobs-list"">
                <div class=""btn-toolbar btn-toolbar-top"">
                    <form class=""row"">
                        <span class=""col-md-3"">
                            <input type=""text"" class=""form-control"" name=""name"" value=""");


            
            #line 53 "..\..\Dashboard\Pages\PublishedPage.cshtml"
                                                                                  Write(Query("name"));

            
            #line default
            #line hidden
WriteLiteral("\" placeholder=\"消息名称\" />\r\n                        </span>\r\n                       " +
" <div class=\"col-md-5\">\r\n                            <div class=\"input-group\">\r\n" +
"                                <input type=\"text\" class=\"form-control\" name=\"co" +
"ntent\" value=\"");


            
            #line 57 "..\..\Dashboard\Pages\PublishedPage.cshtml"
                                                                                         Write(Query("content"));

            
            #line default
            #line hidden
WriteLiteral(@""" placeholder=""消息内容"" />
                                <span class=""input-group-btn"">
                                    <button class=""btn btn-info"">查找</button>
                                </span>
                            </div>
                        </div>
                    </form>
                </div>
                <div class=""btn-toolbar btn-toolbar-top"">
                    <button class=""js-jobs-list-command btn btn-sm btn-primary""
                            data-url=""");


            
            #line 67 "..\..\Dashboard\Pages\PublishedPage.cshtml"
                                 Write(Url.To("/jobs/succeeded/requeue"));

            
            #line default
            #line hidden
WriteLiteral("\"\r\n                            data-loading-text=\"");


            
            #line 68 "..\..\Dashboard\Pages\PublishedPage.cshtml"
                                          Write(Strings.Common_Enqueueing);

            
            #line default
            #line hidden
WriteLiteral("\"\r\n                            disabled=\"disabled\">\r\n                        <spa" +
"n class=\"glyphicon glyphicon-repeat\"></span>\r\n                        ");


            
            #line 71 "..\..\Dashboard\Pages\PublishedPage.cshtml"
                   Write(Strings.Common_RequeueJobs);

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </button>\r\n\r\n                    ");


            
            #line 74 "..\..\Dashboard\Pages\PublishedPage.cshtml"
               Write(Html.PerPageSelector(pager));

            
            #line default
            #line hidden
WriteLiteral(@"
                </div>

                <div class=""table-responsive"">
                    <table class=""table"">
                        <thead>
                            <tr>
                                <th style=""width:60px;"">
                                    <input type=""checkbox"" class=""js-jobs-list-select-all"" />
                                </th>
                                <th>名称</th>
                                <th>内容</th>
                                <th class=""min-width"">重试次数</th>
                                <th class=""min-width align-right"">过期时间</th>
                            </tr>
                        </thead>
                        <tbody>
");


            
            #line 91 "..\..\Dashboard\Pages\PublishedPage.cshtml"
                             foreach (var message in succeededMessages)
                            {

            
            #line default
            #line hidden
WriteLiteral("                                <tr class=\"js-jobs-list-row hover\">\r\n            " +
"                        <td>\r\n                                        <input typ" +
"e=\"checkbox\" class=\"js-jobs-list-checkbox\" name=\"jobs[]\" value=\"");


            
            #line 95 "..\..\Dashboard\Pages\PublishedPage.cshtml"
                                                                                                             Write(message.Id);

            
            #line default
            #line hidden
WriteLiteral("\" />\r\n                                    </td>\r\n                                " +
"    <td class=\"word-break\">\r\n                                        ");


            
            #line 98 "..\..\Dashboard\Pages\PublishedPage.cshtml"
                                   Write(message.Name);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                    </td>\r\n                                    " +
"<td>\r\n                                        ");


            
            #line 101 "..\..\Dashboard\Pages\PublishedPage.cshtml"
                                   Write(message.Content);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                    </td>\r\n                                    " +
"<td>\r\n                                        ");


            
            #line 104 "..\..\Dashboard\Pages\PublishedPage.cshtml"
                                   Write(message.Retries);

            
            #line default
            #line hidden
WriteLiteral("\r\n                                    </td>\r\n                                    " +
"<td class=\"align-right\">\r\n");


            
            #line 107 "..\..\Dashboard\Pages\PublishedPage.cshtml"
                                         if (message.ExpiresAt.HasValue)
                                        {
                                            
            
            #line default
            #line hidden
            
            #line 109 "..\..\Dashboard\Pages\PublishedPage.cshtml"
                                       Write(Html.RelativeTime(message.ExpiresAt.Value));

            
            #line default
            #line hidden
            
            #line 109 "..\..\Dashboard\Pages\PublishedPage.cshtml"
                                                                                       
                                        }

            
            #line default
            #line hidden
WriteLiteral("                                    </td>\r\n\r\n                                </tr" +
">\r\n");


            
            #line 114 "..\..\Dashboard\Pages\PublishedPage.cshtml"
                            }

            
            #line default
            #line hidden
WriteLiteral("                        </tbody>\r\n                    </table>\r\n                <" +
"/div>\r\n                ");


            
            #line 118 "..\..\Dashboard\Pages\PublishedPage.cshtml"
           Write(Html.Paginator(pager));

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n");


            
            #line 120 "..\..\Dashboard\Pages\PublishedPage.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("    </div>\r\n</div>");


        }
    }
}
#pragma warning restore 1591