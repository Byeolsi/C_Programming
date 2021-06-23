# include <stdio.h>
# include <stdlib.h>

// Graph, Vertex, Incidence, Edge ����ü ����
typedef struct Incidence {
	int index;
	struct Incidence *next;
} INC;

typedef struct Vertex {
	int num, minWeight, isCheck;
	INC *toHeader;
} VER;

typedef struct Edge {
	int l, r, weight, isCheck;
} EDG;

typedef struct Graph {
	VER *Ver;
	EDG *Edg;
} GRP;
//

// makeHeader �Լ�
/*
	Vertex ����ü �迭 ���� �ϳ����� ����� ����� �����Ŵ.
*/
void makeHeader(VER *P, int index){
	INC *Header;

	Header = (INC *)malloc(sizeof(INC));
	Header->next = NULL;

	P->toHeader = Header;
}
//

// init_Graph �Լ�
/*
	Graph �� ������ �ʱ�ȭ ���ش�.
	Vertex �� num �� �˸°� �ʱ�ȭ���ְ�, isCheck ���� 0���� �ʱ�ȭ �Ѵ�.
	makeHeader �Լ��� ����Ͽ� Header �� ������ش�.

	Edge �� isCheck �� 0���� �ʱ�ȭ ���ش�.
*/
void init_Graph(GRP *graph, int N, int M){
	int i;

	for (i = 0 ; i < N ; i++){
		graph->Ver[i].num = i + 1;
		graph->Ver[i].isCheck = 0;
		makeHeader(&(graph->Ver[i]), i);
	}
	for (i = 0 ; i < M ; i++){
		graph->Edg[i].isCheck = 0;
	}
}
//

// init_Weight �Լ�
/*
	Vertex �� minWeigt �� ��� ���� �׷������� ������ �ִ� ���Է� �ʱ�ȭ ���ش�.
*/
int init_Weight(GRP *graph, int N, int M){
	int i, maxWeight;

	maxWeight = graph->Edg[0].weight;
	// Edg �迭���� ������ weight �� ��� �湮�ϸ鼭 ���� ū ���� Ž��
	for (i = 1 ; i < M ; i++){
		if (maxWeight < graph->Edg[i].weight){
			maxWeight = graph->Edg[i].weight;
		}
	}
	//

	// Ver �迭���� ������ minWeight �� ��� maxWeight + 1�� �ʱ�ȭ
	for (i = 0 ; i < N ; i++){
		graph->Ver[i].minWeight = maxWeight + 1;
	}
	//

	return maxWeight + 1;
}
//

// addInc �Լ�
/*
	Incidence (���� ����) �� ��� ��� ������ �߰��Ѵ�.
*/
void addInc(INC *H, int index){
	INC *addInc;

	addInc = (INC *)malloc(sizeof(INC));
	addInc->index = index;

	addInc->next = H->next;
	H->next = addInc;
}
//

// deleteInc �Լ�
/*
	���� �Ҵ��� Incidence �� ���� �Ѵ�.
*/
void deleteInc(INC *H){
	INC *deleteInc = H->next;

	H->next = deleteInc->next;
	
	free(deleteInc);
}
//

// renewMinWeight �Լ�
/*
	���� Vertex P �� �������� ����� �ٸ� Vertex �� minWeight �� �����Ѵ�.
*/
void renewMinWeight(GRP *graph, VER *P){
	// indexVer �� minWeight �� ������ Vertex �� index
	// indexEdg �� P�� ����� Edge �� �ϳ��� index
	int indexVer, indexEdg;

	// ù ��° INC ��带 ����Ŵ
	INC *forReferInc = P->toHeader->next;

	while (forReferInc != NULL){
		indexEdg = forReferInc->index;
		// isCheck �� 0 �� ���,
		if (!graph->Edg[indexEdg].isCheck){
			graph->Edg[indexEdg].isCheck = 1;
			
			// Edg[indexEdg].l �� P->num �� ���,
			if (graph->Edg[indexEdg].l == P->num){
				indexVer = graph->Edg[indexEdg].r-1;
			}
			//
			// �ƴ� ���,
			else {
				indexVer = graph->Edg[indexEdg].l-1;
			}
			//

			// ���� minWeight ���� ������ weight �� �� ���� ���,
			if (graph->Ver[indexVer].minWeight > graph->Edg[indexEdg].weight){
				graph->Ver[indexVer].minWeight = graph->Edg[indexEdg].weight;
			}
			//
		}
		forReferInc = forReferInc->next;
	}
}
//

// rfindMST �Լ�
/*
	minWeight �� ������ ��, minWeight �� ���� ���� Vertex �� ������ �ٽ� �Լ��� �����Ѵ�.
*/
int rfindMST(GRP *graph, VER *P, int N){
	int i, minIndex, minWeight, result, existMin = 0;
	
	P->isCheck = 1;
	
	printf(" %d", P->num);

	renewMinWeight(graph, P);

	// ���� �������� ���� Vertex �� Ž���Ͽ� minWeight �� minIndex �� �ʱ�ȭ
	for (i = 0 ; i < N ; i++){
		if (!graph->Ver[i].isCheck){
			minIndex = i;
			minWeight = graph->Ver[i].minWeight;
			// �ּҰ��� ��� �ϳ� ����
			existMin = 1;
			break;
		}
	}
	//

	// �ּҰ��� ��� �ϳ� �����ϴ� ���,
	if (existMin){
		// minWeight ���� �� ���� ���� Vertex ���� Ž��
		for (i = 0 ; i < N ; i++){
			if (minWeight > graph->Ver[i].minWeight && !graph->Ver[i].isCheck){
				minWeight = graph->Ver[i].minWeight;
				minIndex = i;
			}
		}
		//
	}
	//

	// �ּҰ��� ��� �ϳ� �����ϴ� ���,
	if (existMin){
		result = minWeight;
		return result + rfindMST(graph, graph->Ver + minIndex, N);
	}
	//
	// ���� ���,
	else {
		return 0;
	}
	//
}
//

// findMST �Լ�
/*
	rfindMST �Լ��� �����Ű�� ���� ���� �Լ�.
*/
int findMST(GRP *graph, int N){
	VER *S = graph->Ver;

	S->minWeight = 0;

	return rfindMST(graph, S, N);
}
//

// clearData �Լ�
/*
	���� �Ҵ��� ��� �޸𸮸� ���� �Ѵ�.
*/
void clearData(GRP *graph, int N){
	int i;

	for (i = 0 ; i < N ; i++){
		while (graph->Ver[i].toHeader->next != NULL){
			deleteInc(graph->Ver[i].toHeader);
		}
		free(graph->Ver[i].toHeader);
	}
	free(graph->Ver);
	free(graph->Edg);
	free(graph);
}
//

// main �Լ�
/*
	�׷����� ���� �Ҵ��ϰ�, �⺻������ �ʿ��� �����͸� �ʱ�ȭ �Ѵ�.
	�Է��� �޾� �Է� ���� �����͸� graph �� �����ϰ�, �Լ��� ������ ������� ����Ѵ�.
*/
int main(){
	int i, N, M, l, r, weight;
	
	GRP *graph;

	scanf("%d %d", &N, &M);

	graph = (GRP *)malloc(sizeof(GRP));
	graph->Ver = (VER *)malloc(N * sizeof(VER));
	graph->Edg = (EDG *)malloc(M * sizeof(EDG));

	init_Graph(graph, N, M);

	for (i = 0 ; i < M ; i++){
		scanf("%d %d %d", &l, &r, &weight);
		// �Է¹��� �����͸� Edge �� ����
		graph->Edg[i].l = l;
		graph->Edg[i].r = r;
		graph->Edg[i].weight = weight;
		//
		// Vertex �� Incidence �� �߰�
		addInc(graph->Ver[l-1].toHeader, i);
		addInc(graph->Ver[r-1].toHeader, i);
		//
	}

	init_Weight(graph, N, M);

	printf("\n%d", findMST(graph, N));

	// ���� �Ҵ��� �޸� ����
	clearData(graph, N);

	return 0;
}
//