﻿using Render3D.BackEnd;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace renderRepository.entities
{
    public class ClientEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }

        public static ClientEntity FromDomain(Client client)
        {
            int id;
            try
            {
                id = int.Parse(client.Id);
            }
            catch (ArgumentNullException)
            {
                id = 0;
            }
            return new ClientEntity
            {
                Id=id,
                Name = client.Name,
                Password = client.Password,
                RegisterDate = client.RegisterDate
            };
        }

        public Client ToDomain()
        {
            return new Client
            {
                Id = ""+Id,
                Name = Name,
                Password = Password,
                RegisterDate = RegisterDate,
            };
        }
    }
  
}