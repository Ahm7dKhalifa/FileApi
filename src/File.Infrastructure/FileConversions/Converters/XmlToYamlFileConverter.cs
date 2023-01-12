﻿using ChoETL;
using File.Infrastructure.Abstractions;
using File.Infrastructure.Extensions;
using FluentResults;
using System.Text;

namespace File.Infrastructure.FileConversions.Converters
{
    internal sealed class XmlToYamlFileConverter : IFileConverter
    {
        public Task<Result<string>> Convert(string fileContent, CancellationToken cancellationToken)
        {
            using var xmlCoReader = ChoXmlReader.LoadText(fileContent);
            var stringBuilder = new StringBuilder();
            using var yamlWriter = new ChoYamlWriter(stringBuilder);
            yamlWriter.Write(xmlCoReader);
            var yamlContent = stringBuilder.ToString();
            return Task.FromResult(yamlContent.OkIfNotNull());
        }
    }
}
