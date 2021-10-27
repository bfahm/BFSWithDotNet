using BreadthFirstSearch;
using BreadthFirstSearch.Models;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BreadthFirstSearchTests
{
    public class ParserTests : Parser
    {
        [Theory]
        [MemberData(nameof(ParseNodes_ReturnsCorrectListOfNodes_Data))]
        public void ParseNodes_ReturnsCorrectListOfNodes(string input, List<SimpleNode> expectedOutput)
        {
            // Arrange

            // Act
            var nodes = ParseNodes(input);

            // Assert
            nodes.Should().BeEquivalentTo(expectedOutput);
        }

        public static IEnumerable<object[]> ParseNodes_ReturnsCorrectListOfNodes_Data()
        {
            yield return new object[] { "A,B,C", new List<SimpleNode> { SimpleNode.FromName("A"), SimpleNode.FromName("B"), SimpleNode.FromName("C") } };
            yield return new object[] { "A, B, C", new List<SimpleNode> { SimpleNode.FromName("A"), SimpleNode.FromName("B"), SimpleNode.FromName("C") } };
            yield return new object[] { "0,1,2", new List<SimpleNode> { SimpleNode.FromName("0"), SimpleNode.FromName("1"), SimpleNode.FromName("2") } };
            yield return new object[] { "0, 1, 2", new List<SimpleNode> { SimpleNode.FromName("0"), SimpleNode.FromName("1"), SimpleNode.FromName("2") } };
            yield return new object[] { "XYZ,ABC,QWE", new List<SimpleNode> { SimpleNode.FromName("XYZ"), SimpleNode.FromName("ABC"), SimpleNode.FromName("QWE") } };
            yield return new object[] { "XYZ , ABC , QWE", new List<SimpleNode> { SimpleNode.FromName("XYZ"), SimpleNode.FromName("ABC"), SimpleNode.FromName("QWE") } };
        }

        [Theory]
        [MemberData(nameof(ParseAdjacencies_ReturnsAdjacenciesAppliedToNodes_Data))]
        public void ParseAdjacencies_ReturnsAdjacenciesAppliedToNodes(string input, List<Node> parsedNodes, List<Node> expectedOutput)
        {
            // Arrange

            // Act
            ParseAdjacencies(input, parsedNodes);

            // Assert
            parsedNodes.Should().BeEquivalentTo(expectedOutput);
        }

        public static IEnumerable<object[]> ParseAdjacencies_ReturnsAdjacenciesAppliedToNodes_Data()
        {
            var abcNodes = new List<Node>
            {
                Node.FromName("A"),
                Node.FromName("B"),
                Node.FromName("C")
            };

            var abcNodesWithAdjacencies = new List<Node>
            {
                Node.FromNameAndAdjacencies("A", "B"),
                Node.FromNameAndAdjacencies("B", "A", "C"),
                Node.FromNameAndAdjacencies("C", "B")
            };

            var _012Nodes = new List<Node>
            {
                Node.FromName("0"),
                Node.FromName("1"),
                Node.FromName("2")
            };

            var _012NodesWithAdjacencies = new List<Node>
            {
                Node.FromNameAndAdjacencies("0", "1"),
                Node.FromNameAndAdjacencies("1", "2", "0"),
                Node.FromNameAndAdjacencies("2", "1")
            };

            var _0120NodesWithAdjacencies = new List<Node>
            {
                Node.FromNameAndAdjacencies("0", "1", "2"),
                Node.FromNameAndAdjacencies("1", "2", "0"),
                Node.FromNameAndAdjacencies("2", "0", "1")
            };

            var xyzNodes = new List<Node>
            {
                Node.FromName("XYZ"),
                Node.FromName("ABC"),
                Node.FromName("QWE")
            };

            var _xyzNodesWithAdjacencies = new List<Node>
            {
                Node.FromNameAndAdjacencies("XYZ", "ABC"),
                Node.FromNameAndAdjacencies("ABC", "QWE", "XYZ"),
                Node.FromNameAndAdjacencies("QWE", "ABC")
            };

            var abcdNodes = new List<Node>
            {
                Node.FromName("A"),
                Node.FromName("B"),
                Node.FromName("C"),
                Node.FromName("D")
            };

            var abcdNodesWithAdjacencies = new List<Node>
            {
                Node.FromNameAndAdjacencies("A", "B"),
                Node.FromNameAndAdjacencies("B", "A", "C", "D"),
                Node.FromNameAndAdjacencies("C", "B"),
                Node.FromNameAndAdjacencies("D", "B")
            };

            yield return new object[] { "A-B,B-C", abcNodes.ToList(), abcNodesWithAdjacencies.ToList() };
            yield return new object[] { "A-B, B-C", abcNodes.ToList(), abcNodesWithAdjacencies.ToList() };
            yield return new object[] { "0-1,1-2", _012Nodes.ToList(), _012NodesWithAdjacencies.ToList() };
            yield return new object[] { "0-1, 1-2", _012Nodes.ToList(), _012NodesWithAdjacencies.ToList() };
            yield return new object[] { "0-1,1-2, 2-0", _012Nodes.ToList(), _0120NodesWithAdjacencies.ToList() };
            yield return new object[] { "XYZ-ABC,ABC-QWE", xyzNodes.ToList(), _xyzNodesWithAdjacencies.ToList() };
            yield return new object[] { " XYZ-ABC, ABC-QWE ", xyzNodes.ToList(), _xyzNodesWithAdjacencies.ToList() };
            yield return new object[] { "A-B,B-C,B-D", abcdNodes.ToList(), abcdNodesWithAdjacencies.ToList() };
        }
    }
}
