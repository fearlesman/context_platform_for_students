<%@ WebHandler Language="C#" Class="Handler_1" %>

using System;
using System.Web;

public class Handler_1 : IHttpHandler {

    public void ProcessRequest(HttpContext context) {
       
    }

    public bool IsReusable {
        get {
            return true; // 或者根据需要设置为 true
        }
    }
}
