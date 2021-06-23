// 16010980 �̿켮
# include <stdio.h>
# include <stdlib.h>

// Tree ����ü
typedef struct Tree {
	struct Tree *left;
	struct Tree *right;
} NODE;
//

// Queue ����ü
typedef struct Queue {
	// Tree ��带 ����Ű�� ����ü ������
	struct Tree *p_NODE;
	struct Queue *p_next;
} Q;
//

// initTree �Լ�
/*
	������ Ʈ���� �����Ѵ�.
*/
NODE *initTree(){
	int i;
	
	// ��带 �Ҵ��ϴµ� �򰥸��� �ʵ��� ������ �迭�� �ʱ�ȭ
	NODE *T, *T0[19], *T1[9];

	T = (NODE *)malloc(sizeof(NODE));
	T->left = NULL;
	T->right = NULL;
	for (i = 0 ; i < 19 ; i++){
		T0[i] = (NODE *)malloc(sizeof(NODE));
		T0[i]->left = NULL;
		T0[i]->right = NULL;
	}
	for (i = 0 ; i < 9 ; i++){
		T1[i] = (NODE *)malloc(sizeof(NODE));
		T1[i]->left = NULL;
		T1[i]->right = NULL;
	}

	// T
	T->left = T0[0];
	T->right = T1[0];
	//

	// T0[0]
	T0[0]->left = T0[1];
	T0[0]->right = T0[2];
	//
	// T0[1]
	T0[1]->left = T0[3];
	T0[1]->right = T0[4];
	//
	// T0[2]
	T0[2]->left = T0[5];
	T0[2]->right = T0[6];
	//
	// T0[3]
	T0[3]->left = T0[7];
	T0[3]->right = T0[8];
	//
	// T0[4]
	T0[4]->left = NULL;
	T0[4]->right = NULL;
	//
	// T0[5]
	T0[5]->left = T0[9];
	T0[5]->right = T0[10];
	//
	// T0[6]
	T0[6]->left = T0[11];
	T0[6]->right = T0[12];
	//
	// T0[7]
	T0[7]->left = NULL;
	T0[7]->right = NULL;
	//
	// T0[8]
	T0[8]->left = T0[13];
	T0[8]->right = T0[14];
	//
	// T0[9]
	T0[9]->left = NULL;
	T0[9]->right = NULL;
	//
	// T0[10]
	T0[10]->left = NULL;
	T0[10]->right = NULL;
	//
	// T0[11]
	T0[11]->left = NULL;
	T0[11]->right = NULL;
	//
	// T0[12]
	T0[12]->left = NULL;
	T0[12]->right = NULL;
	//
	// T0[13]
	T0[13]->left = NULL;
	T0[13]->right = NULL;
	//
	// T0[14]
	T0[14]->left = T0[15];
	T0[14]->right = T0[16];
	//
	// T0[15]
	T0[15]->left = T0[17];
	T0[15]->right = T0[18];
	//
	// T0[16]
	T0[16]->left = NULL;
	T0[16]->right = NULL;
	//
	// T0[17]
	T0[17]->left = NULL;
	T0[17]->right = NULL;
	//
	// T0[18]
	T0[18]->left = NULL;
	T0[18]->right = NULL;
	//

	// T1[0]
	T1[0]->left = T1[1];
	T1[0]->right = T1[2];
	//
	// T1[1]
	T1[1]->left = NULL;
	T1[1]->right = NULL;
	//
	// T1[2]
	T1[2]->left = T1[3];
	T1[2]->right = T1[4];
	//
	// T1[3]
	T1[3]->left = T1[5];
	T1[3]->right = T1[6];
	//
	// T1[4]
	T1[4]->left = T1[7];
	T1[4]->right = T1[8];
	//
	// T1[5]
	T1[5]->left = NULL;
	T1[5]->right = NULL;
	//
	// T1[6]
	T1[6]->left = NULL;
	T1[6]->right = NULL;
	//
	// T1[7]
	T1[7]->left = NULL;
	T1[7]->right = NULL;
	//
	// T1[8]
	T1[8]->left = NULL;
	T1[8]->right = NULL;
	//

	return T;
}
//

// Enqueue �Լ�
/*
	Tree ��带 ť�� �����Ѵ�.
	�ܼ��ϰ� �����ϴ� ���� �ƴ϶� �ش� Ʈ�� ��带 ����Ű�� ť ��带 �����Ѵ�.
*/
void Enqueue(Q *QH, NODE *v){
	Q *ADD_Q, *PQ = QH;

	ADD_Q = (Q *)malloc(sizeof(Q));

	while (PQ->p_next != NULL){
		PQ = PQ->p_next;
	}

	ADD_Q->p_NODE = v;
	ADD_Q->p_next = PQ->p_next;
	PQ->p_next = ADD_Q;
}
//

// Dequeue �Լ�
/*
	ť���� Tree ��带 �����Ѵ�.
	Tree ��带 �����ϸ鼭 ������ ��带 Return �Ѵ�.
*/
NODE *Dequeue(Q *QH){
	Q *PQ = QH->p_next;
	NODE *R_NODE;

	QH->p_next = PQ->p_next;

	R_NODE = PQ->p_NODE;

	free(PQ);

	return R_NODE;
}
//

// romanSize �Լ�
/*
	��Ʈ���� ũ�⸦ ���Ѵ�.
*/
int romanSize(NODE *v, int *check){
	int l, r;
	
	// �ܺ� ����� ���, 1 �� Return
	if (v->left == NULL && v->right == NULL){
		return 1;
	}
	//

	// ���� v ����� ���� ��Ʈ���� ũ��
	l = romanSize(v->left, check);
	// ���� v ����� ������ ��Ʈ���� ũ��
	r = romanSize(v->right, check);

	// ��带 ��ȸ�ϸ鼭 �θ� ��尡 �ϳ��� �ƴ϶�� check �� ���� 0 �� ��
	if (-5 > l-r || l-r > 5){
		*check = 0;
	}
	//

	// ���� ��Ʈ���� �� ũ�⸦ Return
	return l+r+1;
}
//

// isEmperor �Լ�
/*
	Emperor ������� Ȯ���Ѵ�.
	romanSize �Լ��� �����ϱ� ���� ������ Driver �Լ��̴�.
	���� v ����� ���� ��Ʈ���� ũ��� ������ ��Ʈ���� ũ�⸦ ���Ͽ� v ��尡 �θ� ��尡 �ƴ��� �˻��Ѵ�.
	����, romanSize �Լ��� �������� check �� 1 ���� �˻��Ѵ�.
	����, �� �� ������ �����Ѵٸ�, 1 �� Return �ϰ� �ƴ϶��, 0 �� Return �Ѵ�.
*/
int isEmperor(NODE *v){
	int check = 1, l, r;

	l = romanSize(v->left, &check);
	r = romanSize(v->right, &check);

	if (check == 1 && (-5 > l-r || l-r > 5)){
		return 1;
	}
	else {
		return 0;
	}
}
//

// LevelOrder �Լ�
/*
	���� ��ȸ�� �����Ѵ�.
	���� �ٸ� ���̶��, ���� ��常�� ��ȸ�Ѵ�.
*/
void LevelOrder(NODE *v){
	int Order = 0, EmperorN = 0;

	Q *QH;
	NODE *tmp;

	QH = (Q *)malloc(sizeof(Q));
	QH->p_next = NULL;

	Enqueue(QH, v);

	while (QH->p_next != NULL){
		tmp = Dequeue(QH);
		Order++;
		
		// tmp ��尡 Emperor ������� Ȯ��
		if (isEmperor(tmp)){
			printf("%d	Ȳ�����\n", Order);
			EmperorN++;
		}
		//

		// ���� ��常�� ��ȸ�ϱ� ���� if ���ǹ��� �ٸ��� ��
		if ((tmp->left)->left != NULL || (tmp->left)->right != NULL){
			Enqueue(QH, tmp->left);
		}
		if ((tmp->right)->left != NULL || (tmp->right)->right != NULL){
			Enqueue(QH, tmp->right);
		}
		//
	}

	printf("�湮�� ���� ��� �� %d��, Ȳ����� �� %d��\n", Order, EmperorN);
}
//

// main �Լ�
int main(){
	NODE *T;

	T = initTree();

	LevelOrder(T);

	return 0;
}
//