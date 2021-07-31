# Data structures
- [Data structures](#data-structures)
	- [Balanced Trees](#balanced-trees)
		- [When is a tree balanced?](#when-is-a-tree-balanced)
	- [Self-balanced Trees](#self-balanced-trees)
	- [Rotations](#rotations)
		- [Right rotation](#right-rotation)
		- [Left rotation](#left-rotation)
	- [Linked list](#linked-list)
		- [Time complexity](#time-complexity)
## Balanced Trees 

___

The **height** of a tree is the height of it's **root**.

And the **height** of a node is the ***number of edges*** on the longest path from the **node** to a **leaf**.
  
### When is a tree balanced?
  
A tree is balanced if these ***three trules*** are met for **each node** 

1. The difference between **absolute height** of the *left* subtree and *right* subtree is not more than **1**.
2. The ***left*** subtree is balanced.
3. The ***right*** subtree is balanced.

## Self-balanced Trees

___

## Rotations
  
Given two nodes: A and B, A being the father of B.
  
### Right rotation

A gains its child's right child as its new **left** child; and A becomes the new B's **right** child.
  
### Left rotation
  
A gains its child's left child as its new **right** child; and A becomes the new B's **left** child.
  
![Tree rotation](images/treerotation.png)

## Linked list

___

- Linked list are physically represented in memory
- Each node is made of two parts: The data, and a pointer to the next node.
- The first node is the **head** and the last node is the **tail**. 

### Time complexity

| Action | Average | Worst |
| ------ | ------  | ----- |
| Search | Θ(n) | O(n)|
| Insert | Θ(1) | O(1)|
| Delete | Θ(1) | O(1)|