﻿// See https://aka.ms/new-console-template for more information
using System;

int[] heap = {5, 9, 15, 32, 64, 8, 4, 7, 2, 1, 75, 82, 63, 92, 82, 43, 13, 26, 79};

/*
ArrayHeapsorter<int> heapsorter = new ArrayHeapsorter<int>(heap);
int[] heap2 = heapsorter.Sort();
*/
TreeHeapsorter<int> treeHeapsorter = new TreeHeapsorter<int>(heap);

//treeHeapsorter.Sort();
