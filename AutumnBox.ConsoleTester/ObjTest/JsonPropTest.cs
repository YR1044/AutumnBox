﻿/* =============================================================================*\
*
* Filename: JsonPropTest
* Description: 
*
* Version: 1.0
* Created: 2017/10/29 16:45:29 (UTC+8:00)
* Compiler: Visual Studio 2017
* 
* Author: zsh2401
* Company: I am free man
*
\* =============================================================================*/
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutumnBox.ConsoleTester.ObjTest
{
    [JsonObject(MemberSerialization.OptOut)]
    public static class JsonPropTest
    {
        [JsonProperty("Name")]
        public static string Name { get; set; } = "haha";
        [JsonProperty("NamesJsonProp")]
        public static string[] Names { get; set; } = { "x", "x" };
        public static void Run()
        {
            //var fuck = new JsonPropTest();
            //JsonConvert.SerializeObject()
            //Console.WriteLine(DataHelper.JsonPropertyNameOf(typeof(fuck), nameof(fuck.Names)));
            //string json = JsonConvert.SerializeObject(new JsonPropTest());
            //var props = new JsonPropTest().GetType().GetProperties();

            //foreach (var prop in props)
            //{
            //    Console.WriteLine(prop.Name);
            //    if (!prop.IsDefined(typeof(JsonPropertyAttribute), true)) continue;
            //    //var pAttrs = prop.GetCustomAttributes(false);
            //    var j = (JsonPropertyAttribute)Attribute.GetCustomAttribute(prop, typeof(JsonPropertyAttribute));
            //    Console.WriteLine(j.PropertyName);
            //}
        }
    }
}
