using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using TestApiFintech.Models;

namespace TestApiFintech.Controllers
{
    public class Bot
    {
        public string GetToken()
        {
            string method = "POST";
            string uri = "https://finx22openplatform.fintech-galaxy.com/my/logins/direct";

            string username = "sinanyigin";
            string consumerKey = "xkpblx501zktiyperxipr1ronlxfx3odgsdwslfs";

            string userName1 = "Amina.Eg.01";
            string password1 = "X!133210e1";
            string consumerKey1 = "ilev0u3t1urz00aacjp34xrrbyhoqsxta0jfzsh0";

            string directLogin = "DirectLogin username=\"sinanyigin\", password=\"Aminmelalle87!\",  consumer_key=\"xkpblx501zktiyperxipr1ronlxfx3odgsdwslfs\"";


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = method;
            request.Headers.Add("Authorization", directLogin);
            request.Headers.Add("Content-Type", "application/json");

            var result = request.GetResponse();
            Stream dataStream = result.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            result.Close();

            var deger = responseFromServer;

            return deger;
        }


        public void Transactions()
        {

        }


        public List<NewCustomer> GetFireHoseCustomersAndTransactions()
        {
            var newCustomers = new List<NewCustomer>();

            string token = GetToken();
            var jsonToken = (JObject)JsonConvert.DeserializeObject(token);
            string uri = string.Empty;
            string method = "GET";

            var allCustomers = new List<JObject>();

            var bankList = new List<string>();
            bankList.Add("ftg.01.bh.bh");
            bankList.Add("ftg.01.aedu.aedu");
            bankList.Add("ftg.01.eg.eg");
            bankList.Add("ftg.01.jo.jo");
            bankList.Add("ftg.01.sar.sa");
            bankList.Add("ftg.01.uk.uk");


            foreach (var item in bankList)
            {
                uri = "https://finx22openplatform.fintech-galaxy.com/obp/v4.0.0/banks/" + item + "/firehose/customers";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.Method = method;
                request.Headers.Add("Authorization", "DirectLogin token=\"" + jsonToken["token"] + "\"");
                request.Headers.Add("Cookie", "JSESSIONID=cs78uu0qnltpt49ktpmcneh1");

                string responseFromServer = string.Empty;
                var deger = string.Empty;

                HttpWebResponse result = new HttpWebResponse();


                result = (HttpWebResponse)request.GetResponse();
                Stream dataStream = result.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                responseFromServer = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                result.Close();

                deger = responseFromServer;
                allCustomers.Add((JObject)JsonConvert.DeserializeObject(responseFromServer));


            }

            foreach (var item in allCustomers)
            {
                var customers = item["customers"];
                var customersCount = customers.Count();

                for (int i = 0; i < customersCount; i++)
                {
                    var creditRating = customers[i]["credit_rating"];
                    var creditLimit = customers[i]["credit_limit"];

                    var newCustomer = new NewCustomer()
                    {
                        BankId = customers[i]["bank_id"].ToString(),
                        CustomerId = customers[i]["customer_id"].ToString(),
                        CustomerNumber = customers[i]["customer_number"].ToString(),
                        DateOfBirth = customers[i]["date_of_birth"].ToString(),
                        Email = customers[i]["email"].ToString(),
                        EmploymentStatus = customers[i]["employment_status"].ToString(),
                        HighestEducation = customers[i]["highest_education_attained"].ToString(),
                        PhoneNumber = customers[i]["mobile_phone_number"].ToString(),
                        RelationStatus = customers[i]["relationship_status"].ToString(),
                    };

                    var CreditRatings = new CreditRating()
                    {
                        Rating = creditRating["rating"].ToString(),
                        Source = creditRating["source"].ToString(),
                    };

                    newCustomer.CreditRatings.Add(CreditRatings);

                    var CreditLimits = new CreditLimit()
                    {
                        Amount = decimal.Parse(creditLimit["amount"].ToString()),
                        Currency = creditLimit["currency"].ToString()
                    };
                    newCustomer.CreditLimits.Add(CreditLimits);


                    uri = "https://finx22openplatform.fintech-galaxy.com/obp/v4.0.0/banks/" + newCustomer.BankId + "/firehose/accounts/" + newCustomer.CustomerId + "/views/owner/transactions";
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                    request.Method = method;
                    request.Headers.Add("Authorization", "DirectLogin token=\"" + jsonToken["token"] + "\"");
                    request.Headers.Add("Cookie", "JSESSIONID=cs78uu0qnltpt49ktpmcneh1");

                    string responseFromServer = string.Empty;
                    var deger = string.Empty;

                    HttpWebResponse result = new HttpWebResponse();
                    result = (HttpWebResponse)request.GetResponse();
                    Stream dataStream = result.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    responseFromServer = reader.ReadToEnd();
                    reader.Close();
                    dataStream.Close();
                    result.Close();

                    deger = responseFromServer;


                    newCustomers.Add(newCustomer);


                }

            }

            return newCustomers;
        }


        public List<Customers> GetFireHoseAccountsAtBank()
        {
            string token = GetToken();
            var jsonToken = (JObject)JsonConvert.DeserializeObject(token);


            var bankList = new List<string>();
            bankList.Add("ftg.01.bh.bh");
            bankList.Add("ftg.01.aedu.aedu");
            bankList.Add("ftg.01.eg.eg");
            bankList.Add("ftg.01.jo.jo");
            bankList.Add("ftg.01.sar.sa");
            bankList.Add("ftg.01.uk.uk");

            var allCustomers = new List<JObject>();

            var customerList = new List<Customers>();

            foreach (var item in bankList)
            {
                string method = "GET";
                string uri = "https://finx22openplatform.fintech-galaxy.com/obp/v4.0.0/banks/" + item + "/firehose/accounts/views/owner";

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.Method = method;
                request.Headers.Add("Authorization", "DirectLogin token=\"" + jsonToken["token"] + "\"");
                request.Headers.Add("Cookie", "JSESSIONID=cs78uu0qnltpt49ktpmcneh1");

                string responseFromServer = string.Empty;
                var deger = string.Empty;

                HttpWebResponse result = new HttpWebResponse();


                result = (HttpWebResponse)request.GetResponse();
                Stream dataStream = result.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                responseFromServer = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                result.Close();

                deger = responseFromServer;


                allCustomers.Add((JObject)JsonConvert.DeserializeObject(responseFromServer));


                foreach (var customers in allCustomers)
                {

                    var customersAtBank = customers["accounts"].ToList();

                    foreach (var customerAtBank in customersAtBank)
                    {
                        var customer = new Customers()
                        {
                            Id = Guid.NewGuid(),
                            CustomerId = customerAtBank["id"].ToString(),
                            BankId = customerAtBank["bank_id"].ToString(),
                            Label = customerAtBank["label"].ToString(),
                            Number = Convert.ToInt64(customerAtBank["number"]),
                            Type = customerAtBank["type"].ToString(),

                        };

                        var owners = customerAtBank["owners"];
                        var ownersCount = owners.Count();
                        var balances = customerAtBank["balance"];
                        var accountRoutings = customerAtBank["account_routings"];
                        var accountRoutingsCount = accountRoutings.Count();

                        for (int i = 0; i < ownersCount; i++)
                        {
                            var owner = new Owner()
                            {
                                CustomerId = customer.Id,
                                DisplayName = owners[i]["display_name"].ToString(),
                                OwnerId = owners[i]["id"].ToString(),
                                Provider = owners[i]["provider"].ToString()
                            };
                            customer.Owners.Add(owner);
                        }


                        var balance = new Balance()
                        {
                            CustomerId = customer.Id,
                            Amount = Convert.ToDecimal(balances["amount"]),
                            Currency = balances["currency"].ToString()
                        };
                        customer.Balances.Add(balance);

                        var hede = accountRoutings[0]["address"].ToString();


                        for (int i = 0; i < accountRoutingsCount; i++)
                        {
                            var accountRouting = new AccountRoutings()
                            {
                                CustomerId = customer.Id,
                                Address = accountRoutings[i]["address"].ToString(),
                                Schema = accountRoutings[i]["scheme"].ToString(),

                            };

                            customer.AccountRoutings.Add(accountRouting);
                        }

                        uri = "https://finx22openplatform.fintech-galaxy.com/obp/v4.0.0/banks/" + customer.BankId + "/firehose/accounts/" + customer.CustomerId + "/views/owner/transactions";
                        request = (HttpWebRequest)WebRequest.Create(uri);
                        request.Method = method;
                        request.Headers.Add("Authorization", "DirectLogin token=\"" + jsonToken["token"] + "\"");
                        request.Headers.Add("Cookie", "JSESSIONID=cs78uu0qnltpt49ktpmcneh1");

                        responseFromServer = string.Empty;
                        deger = string.Empty;

                        result = new HttpWebResponse();


                        result = (HttpWebResponse)request.GetResponse();
                        dataStream = result.GetResponseStream();
                        reader = new StreamReader(dataStream);
                        responseFromServer = reader.ReadToEnd();
                        reader.Close();
                        dataStream.Close();
                        result.Close();

                        deger = responseFromServer;



                        customerList.Add(customer);
                    }
                }
            }
            var custoom = customerList;

            foreach (var item in customerList)
            {

            }

            return customerList;

        }



        public void AllFunction()
        {
            int i = 0;

            string token = GetToken();

            var jsonToken = (JObject)JsonConvert.DeserializeObject(token);

            #region https://finx22openplatform.fintech-galaxy.com/obp/v4.0.0/config

            string method = "GET";
            string uri = "https://finx22openplatform.fintech-galaxy.com/obp/v4.0.0/config";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = method;
            request.Headers.Add("Authorization", "DirectLogin token=\"" + jsonToken["token"] + "\"");
            request.Headers.Add("Cookie", "JSESSIONID=cs78uu0qnltpt49ktpmcneh1");

            string responseFromServer = string.Empty;
            var deger = string.Empty;

            HttpWebResponse result = new HttpWebResponse();

            try
            {
                result = (HttpWebResponse)request.GetResponse();
                Stream dataStream = result.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                responseFromServer = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                result.Close();

                deger = responseFromServer;
            }
            catch (System.Exception ex)
            {

                if (ex.Message.Contains("(401)"))
                {
                    token = GetToken();
                    jsonToken = (JObject)JsonConvert.DeserializeObject(token);

                }
            }


            if (i % 2 == 1)
            {
                Thread.Sleep(10000);
            }
            else
            {
                Thread.Sleep(20000);
            }

            #endregion

            #region https://finx22openplatform.fintech-galaxy.com/obp/v4.0.0/connector/loopback

            method = "GET";
            uri = "https://finx22openplatform.fintech-galaxy.com/obp/v4.0.0/connector/loopback";

            request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = method;
            request.Headers.Add("Authorization", "DirectLogin token=\"" + jsonToken["token"] + "\"");
            request.Headers.Add("Cookie", "JSESSIONID=cs78uu0qnltpt49ktpmcneh1");

            responseFromServer = string.Empty;
            deger = string.Empty;

            result = new HttpWebResponse();

            try
            {
                result = (HttpWebResponse)request.GetResponse();
                Stream dataStream = result.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                responseFromServer = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                result.Close();

                deger = responseFromServer;
            }
            catch (System.Exception ex)
            {

                if (ex.Message.Contains("(401)"))
                {
                    token = GetToken();
                    jsonToken = (JObject)JsonConvert.DeserializeObject(token);

                }
            }

            if (i % 2 == 1)
            {
                Thread.Sleep(10000);
            }
            else
            {
                Thread.Sleep(20000);
            }

            #endregion

            #region https://finx22openplatform.fintech-galaxy.com/obp/v4.0.0/connector/loopback

            method = "GET";
            uri = "https://finx22openplatform.fintech-galaxy.com/obp/v4.0.0/connector/loopback";

            request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = method;
            request.Headers.Add("Authorization", "DirectLogin token=\"" + jsonToken["token"] + "\"");
            request.Headers.Add("Cookie", "JSESSIONID=cs78uu0qnltpt49ktpmcneh1");

            responseFromServer = string.Empty;
            deger = string.Empty;

            result = new HttpWebResponse();

            try
            {
                result = (HttpWebResponse)request.GetResponse();
                Stream dataStream = result.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                responseFromServer = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                result.Close();

                deger = responseFromServer;
            }
            catch (System.Exception ex)
            {

                if (ex.Message.Contains("(401)"))
                {
                    token = GetToken();
                    jsonToken = (JObject)JsonConvert.DeserializeObject(token);

                }
            }

            if (i % 2 == 1)
            {
                Thread.Sleep(10000);
            }
            else
            {
                Thread.Sleep(20000);
            }

            #endregion



            i = i += 1;

        }

    }
}