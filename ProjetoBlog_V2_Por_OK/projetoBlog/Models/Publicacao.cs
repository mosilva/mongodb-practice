﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace projetoBlog.Models
{
    public class Publicacao
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Autor { get; set; }

        public string Titulo { get; set; }

        public string Conteudo { get; set; }

        public List<string> Tags { get; set; }

        public DateTime DataCriacao { get; set; }

        public List<Comentario> Comentarios { get; set; }













    }
}