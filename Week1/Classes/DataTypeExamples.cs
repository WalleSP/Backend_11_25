public class DataTypeExamples
{
    // fields
    // Primitive datatypes
    public string? StringValue;
    /// <summary>
    /// Integer datatype: whole numbers
    /// </summary>
    public int WholeNumber; // not empty, defaults to 0
    /// <summary>
    /// double datatype: decimal numbers, less precise than decimal type, more precise than float.
    /// </summary>
    public double DecimalNumber;
    /// <summary>
    /// character datatype: single character in unicode ( , $, ?, a,b,c etc.
    /// </summary>
    public char CharacterValue;
    /// <summary>
    /// boolean datatype: holds a true or false value, defaults to "false"
    /// </summary>
    public bool BooleanValue;
    /// <summary>
    /// byte datatype: holds a byte as a value
    /// </summary>
    public byte ByteValue;

    // Collection of datatypes <--> data structures

    // Array -- fixed size (defined by the elements it contains)
    public string[]? ShoppingListAsArray;
    // List -- dynamically sized (can grow or shrink as we see fit)
    public List<string>? ShoppingListAsList;

    // Dictionary -- a "hash-map" or "dictionary" of key-value pairs
    public Dictionary<int, string>? DictionaryStructure;
}