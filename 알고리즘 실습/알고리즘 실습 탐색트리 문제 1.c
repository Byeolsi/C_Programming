# include <stdio.h>
# include <stdlib.h>

typedef struct Node {
	int key;
	int height;
	struct Node *parent;
	struct Node *p_left;
	struct Node *p_right;
} NODE;

void insertNode(NODE **R, int key){
	NODE *P = *R, *ADD_NODE;

	ADD_NODE = (NODE *)malloc(sizeof(NODE));
	ADD_NODE->key = key;
	ADD_NODE->parent = NULL;
	ADD_NODE->p_left = NULL;
	ADD_NODE->p_right = NULL;

	if (P == NULL){
		*R = ADD_NODE;
	}
	else {
		while (P != NULL){
			if (key > P->key){
				if (P->p_right == NULL){
					P->p_right = ADD_NODE;
					ADD_NODE->parent = P;
					return;
				}
				P = P->p_right;
			}
			else {
				if (P->p_left == NULL){
					P->p_left = ADD_NODE;
					ADD_NODE->parent = P;
					return;
				}
				P = P->p_left;
			}
		}
	}
}

int searchKey(NODE *R, int key){
	NODE *P = R;

	while (P != NULL){
		if (P->key > key){
			P = P->p_left;
		}
		else if (P->key < key){
			P = P->p_right;
		}
		else {
			return P->key;
		}
	}
	return -1;
}

int deleteNode(NODE **R, int key){
	int result;

	NODE *P = *R, *DELETE_NODE;

	result = searchKey(*R, key);
	if (result == -1){
		return -1;
	}
	else {
		while (P->key != key){
			if (P->key > key){
				P = P->p_left;
			}
			else if (P->key < key){
				P = P->p_right;
			}
		}

		DELETE_NODE = P;
		// ������ ��� ���� �ڽ��� ���� ���
		if (DELETE_NODE->p_left != NULL){
			// ������ ��� ���� ������ �ڽ��� ���� ���
			if (DELETE_NODE->p_right != NULL){
				// ������ ��� ���� ������ �ڽ��� �ְ�, ������ �ڽ��� ���� �ڽ��� ���� ���
				if ((DELETE_NODE->p_right)->p_left != NULL){
					P = (P->p_right)->p_left;

					// ���� �ڽ��� ���� �� ���� P �̵�
					while (P->p_left != NULL){
						P = P->p_left;
					}

					// P �� ������ �ڽ��� ���� ���
					if (P->p_right != NULL){
						(P->p_right)->parent = P->parent;
						(P->parent)->p_left = P->p_right;
					}
					else {
						(P->parent)->p_left = NULL;
					}

					P->parent = DELETE_NODE->parent;
					if (DELETE_NODE != *R){
					// ������ ��尡 parent �� ���� �ڽ��� ���
						if ((DELETE_NODE->parent)->p_left == DELETE_NODE){
							(DELETE_NODE->parent)->p_left = P;
						}
						// ������ ��尡 parent �� ������ �ڽ��� ���
						else if ((DELETE_NODE->parent)->p_right == DELETE_NODE){
							(DELETE_NODE->parent)->p_right = P;
						}
					}
					else {
						*R = P;
					}
					P->p_left = DELETE_NODE->p_left;
					(P->p_left)->parent = P;
					P->p_right = DELETE_NODE->p_right;
					(P->p_right)->parent = P;
				}
				// ���� �ڽİ� ������ �ڽ��� ������, ������ �ڽ��� ���� �ڽ��� ���� ���
				else {
					P = P->p_right;
					
					P->parent = DELETE_NODE->parent;
					if (DELETE_NODE != *R){
						if ((DELETE_NODE->parent)->p_left == DELETE_NODE){
							(DELETE_NODE->parent)->p_left = P;
						}
						else if ((DELETE_NODE->parent)->p_right == DELETE_NODE){
							(DELETE_NODE->parent)->p_right = P;
						}
					}
					else {
						*R = P;
					}
					P->p_left = DELETE_NODE->p_left;
					(P->p_left)->parent = P;
				}
			}
			// ���� �ڽĸ� �ִ� ���
			else {
				P = P->p_left;

				P->parent = DELETE_NODE->parent;
				if (DELETE_NODE != *R){
					if ((DELETE_NODE->parent)->p_left == DELETE_NODE){
						(DELETE_NODE->parent)->p_left = P;
					}
					else if ((DELETE_NODE->parent)->p_right == DELETE_NODE){
						(DELETE_NODE->parent)->p_right = P;
					}
				}
				else {
					*R = P;
				}
			}
		}
		// ���� �ڽ��� ������, ������ �ڽ��� �ִ� ���
		else if (P->p_right != NULL){
			P = P->p_right;

			P->parent = DELETE_NODE->parent;
			if (DELETE_NODE != *R){
				if ((DELETE_NODE->parent)->p_left == DELETE_NODE){
					(DELETE_NODE->parent)->p_left = P;
				}
				else if ((DELETE_NODE->parent)->p_right == DELETE_NODE){
					(DELETE_NODE->parent)->p_right = P;
				}
			}
			else {
				*R = P;
			}
		}
		// �ڽ��� ���� ���
		else {
			if (DELETE_NODE != *R){
				if ((DELETE_NODE->parent)->p_left == DELETE_NODE){
					(DELETE_NODE->parent)->p_left = NULL;
				}
				else if ((DELETE_NODE->parent)->p_right == DELETE_NODE){
					(DELETE_NODE->parent)->p_right = NULL;
				}
			}
			else {
				*R = P;
			}
		}
		free(DELETE_NODE);

		return result;
	}
}

void printTree(NODE *P){

	printf(" %d", P->key);
	if (P->p_left != NULL){
		printTree(P->p_left);
	}
	if (P->p_right != NULL){
		printTree(P->p_right);
	}
}

void clear(NODE **R, NODE *P){
	if (P->p_left != NULL){
		clear(R, P->p_left);
	}
	if (P->p_right != NULL){
		clear(R, P->p_right);
	}
	deleteNode(R, P->key);
}

int main(){
	char order;
	int key, result;
	
	NODE *R = NULL;

	scanf("%c", &order);
	while (order != 'q'){
		switch (order){
		case 'i':
			scanf("%d", &key);
			insertNode(&R, key);
			break;
		case 'd':
			scanf("%d", &key);
			result = deleteNode(&R, key);
			if (result == -1){
				printf("X\n");
			}
			else {
				printf("%d\n", result);
			}
			break;
		case 's':
			scanf("%d", &key);
			result = searchKey(R, key);
			if (result == -1){
				printf("X\n");
			}
			else {
				printf("%d\n", result);
			}
			break;
		case 'p':
			printTree(R);
			printf("\n");
			break;
		}
		scanf("%c", &order);
	}

	clear(&R, R);

	return 0;
}