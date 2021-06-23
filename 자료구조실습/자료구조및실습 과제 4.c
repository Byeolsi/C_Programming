// 16010980 �̿켮
# include <stdio.h>
# include <stdlib.h>
# include <string.h>

// Tree ����ü
typedef struct Tree {
	char data[100];
	struct Tree *left;
	struct Tree *right;
} NODE;
//

// makeExternalNode �Լ�
/*
	�ܺ� ��带 ����� �Լ�
	���� ��带 �����.
*/
NODE *makeExternalNode(){
	NODE *v;

	v = (NODE *)malloc(sizeof(NODE));

	printf("Enter decision: ");
	gets(v->data);
	
	v->left = NULL;
	v->right = NULL;
	
	return v;
}
//

// makeInternalNode �Լ�
/*
	���� ��带 ����� �Լ�
	���� ��带 �����.
*/
NODE *makeInternalNode(int N){
	char answer[4];
	
	NODE *v;

	v = (NODE *)malloc(sizeof(NODE));

	printf("Enter question: ");
	gets(v->data);
	
	// ����� yes �� ���,
	printf("Question if yes to \'%s\'? ", v->data);
	
	// N �� 1 ������Ų��. �� �������� �Լ��� ȣ���� ��, �� ū ���� N �� ���ڷ� ����.
	N++;
	// ���� ������ 3 ~ 5 ���� Ȯ���Ѵ�. ����, �ƴ϶�� �ݺ��Ѵ�.
	do {
		gets(answer);
		if (strcmp(answer, "yes") != 0 && N < 3 || strcmp(answer, "yes") == 0 && N > 4){
			printf("need 3 ~ 5 questions\n");
			printf("Question if yes to \'%s\'? ", v->data);
		}
	} while (strcmp(answer, "yes") != 0 && N < 3 || strcmp(answer, "yes") == 0 && N > 4);
	//

	// ��� �κ�
	if (strcmp(answer, "yes") == 0)
		v->left = makeInternalNode(N);
	else
		v->left = makeExternalNode();
	//

	// ����� no �� ���,
	printf("Question if no to \'%s\'? ", v->data);

	// ���� ������ 3 ~ 5 ���� Ȯ���Ѵ�. ����, �ƴ϶�� �ݺ��Ѵ�.
	do {
		gets(answer);
		if (strcmp(answer, "yes") != 0 && N < 3 || strcmp(answer, "yes") == 0 && N > 4){
			printf("need 3 ~ 5 questions\n");
			printf("Question if no to \'%s\'? ", v->data);
		}
	} while (strcmp(answer, "yes") != 0 && N < 3 || strcmp(answer, "yes") == 0 && N > 4);

	// ��� �κ�
	if (strcmp(answer, "yes") == 0)
		v->right = makeInternalNode(N);
	else
		v->right = makeExternalNode();
	//

	return v;
}
//

// processNode �Լ�
/*
	���ϴ� ���� ã�� ���� �Լ�
*/
void processNode(NODE *v){
	char answer[4];
	
	// ���� ����� ���,
	if (v->left != NULL || v->right != NULL){
		printf("%s ", v->data);
		gets(answer);
	}
	//
	// ���� ����� ���,
	else {
		printf("%s\n", v->data);
	}
	//

	// ��� �κ�
	if (v->left != NULL || v->right != NULL){
		if (strcmp(answer, "yes") == 0)
			processNode(v->left);
		else
			processNode(v->right);
	}
	//
}
//

// buildDecisionTree �Լ�
/*
	makeInternalNode �� Driver
*/
NODE *buildDecisionTree(int N){
	NODE *v;

	printf("***Let's build a dichotomous QA system\n");
	v = makeInternalNode(N);
	return v;
}
//

// runDecisionTree �Լ�
/*
	processNode �� Driver
*/
void runDecisionTree(NODE *v){
	printf("***Please answer questions\n");
	processNode(v);
}
//

// main �Լ�
int main(){
	int i;

	NODE *v;

	v = buildDecisionTree(0);

	// 3 �� ã��
	for (i = 0 ; i < 3 ; i++){
		runDecisionTree(v);
	}
	//
	return 0;
}
//