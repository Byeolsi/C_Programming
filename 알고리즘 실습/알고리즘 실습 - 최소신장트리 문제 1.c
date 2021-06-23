# include <stdio.h>
# include <stdlib.h>

typedef struct Vertices {
	int Num;
	int minWeight;
	int flag;
} VER;

typedef struct Edge {
	int l, r, weight, flag;
} EDG;

void initWeight(VER *Ver, EDG *Edg, int N, int M){
	int i, maxWeight = 0;

	for (i = 0 ; i < M ; i++){
		if (Edg[i].weight > maxWeight){
			maxWeight = Edg[i].weight;
		}
	}

	for (i = 0 ; i < N ; i++){
		Ver[i].minWeight = maxWeight + 1;
	}
}

// findMST �Լ�
/*
	�� ��� ����� �ʱ� ����ġ�� �����̶�� ���� �Ͽ� �Լ��� �����Ѵ�.

	ù ��° ����� minWeight�� 0���� �ϰ�, flag�� 1�� �д�.
	ù ��° ���� ����Ǿ� �ִ� ����� �ּ� ����ġ�� �����Ѵ�. (Edg[i].flag �� 0 ���� Ȯ���� ��,)
	ù ��° ���� �ٸ� ��带 �����Ű�� ����� flag �� 1�� �д�.
	// �ݺ�
	flag�� 0�� ��� �� ���� ����ġ�� ���� ��带 �����Ѵ�.
	�� ����� flag�� 1�� �д�.
	�� ���� ����Ǿ� �ִ� ����� �ּ� ����ġ�� �����Ѵ�. (Edg[i].flag �� 0 ���� Ȯ���� ��,)
	�� ���� �ٸ� ��带 �����Ű�� ����� flag �� 1�� �д�.
	//
*/
int findMST(VER *Ver, EDG *Edg, int **Matrix, int N){
	int i, j, minWeight, minIndex, verIndex, edgIndex, minCost = 0;
	
	VER *selectedVer = NULL;

	selectedVer = Ver;
	selectedVer->minWeight = 0;
	selectedVer->flag = 1;
	printf(" %d", selectedVer->Num);

	for (i = 0 ; i < N-1 ; i++){
		for (j = 0 ; j < N ; j++){
			if (Matrix[(selectedVer->Num)-1][j] > -1){
				edgIndex = Matrix[(selectedVer->Num)-1][j];
	
				if (Edg[edgIndex].flag == 1){
					continue;
				}
				Edg[edgIndex].flag = 1;
			
				if (Edg[edgIndex].l == selectedVer->Num){
					verIndex = (Edg[edgIndex].r)-1;
				}
				else {
					verIndex = (Edg[edgIndex].l)-1;
				}
			
				if (Ver[verIndex].minWeight > Edg[edgIndex].weight){
					Ver[verIndex].minWeight = Edg[edgIndex].weight;
				}
			}
		}
		for (j = 0 ; j < N ; j++){
			if (Ver[j].flag == 0){
				minWeight = Ver[j].minWeight;
				minIndex = j;
				break;
			}
		}
		for (j = 0 ; j < N ; j++){
			if (Ver[j].minWeight < minWeight && Ver[j].flag == 0){
				minWeight = Ver[j].minWeight;
				minIndex = j;
			}
		}
		selectedVer = Ver + minIndex;
		selectedVer->flag = 1;

		minCost += minWeight;

		printf(" %d", selectedVer->Num);
	}
	printf("\n");

	return minCost;
}

int main(){
	int i, j, N, M, result, **Matrix;

	VER *Ver;
	EDG *Edg;

	scanf("%d %d", &N, &M);

	Ver = (VER *)malloc(N*sizeof(VER));
	for (i = 0 ; i < N ; i++){
		Ver[i].Num = i+1;
		Ver[i].flag = 0;
	}

	Edg = (EDG *)malloc(M*sizeof(EDG));
	for (i = 0 ; i < M ; i++){
		Edg[i].flag = 0;
	}

	Matrix = (int **)malloc(N*sizeof(int *));
	for (i = 0 ; i < N ; i++){
		Matrix[i] = (int *)malloc(sizeof(int));
	}
	for (i = 0 ; i < N ; i++){
		for (j = 0 ; j < N ; j++){
			Matrix[i][j] = -1;
		}
	}

	for (i = 0 ; i < M ; i++){
		scanf("%d %d %d", &(Edg[i].l), &(Edg[i].r), &(Edg[i].weight));
		Matrix[Edg[i].l-1][Edg[i].r-1] = i;
		Matrix[Edg[i].r-1][Edg[i].l-1] = i;
	}

	initWeight(Ver, Edg, N, M);
	result = findMST(Ver, Edg, Matrix, N);
	printf("%d\n", result);

	free(Ver);
	free(Edg);
	for (i = 0 ; i < N ; i++){
		free(Matrix[i]);
	}
	free(Matrix);

	return 0;
}