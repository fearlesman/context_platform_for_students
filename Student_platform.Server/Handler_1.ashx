<%@ WebHandler Language="C#" Class="Handler_1" %>

using System;
using System.Web;

public class Handler_1 : IHttpHandler {

    public void ProcessRequest(HttpContext context) {
       
    }

    public bool IsReusable {
        get {
            return true; // ���߸�����Ҫ����Ϊ true
        }
    }
}
