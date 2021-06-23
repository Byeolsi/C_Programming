# include <stdio.h>
# include <stdlib.h>
# include <Windows.h>

// ����ü ���� 
typedef struct Stack {
	int num;
	// ���� next 
	struct Stack *p_enext;
	// �ּҰ� next 
	struct Stack *p_mnext;
} NODE;

// push �Լ� 
/*
	���� ���ÿ� ��带 �ִ´�.
	���� ���� ��� ���� (Top) �� �ִ´�.
	���� ������ ����� ���Ұ� �ּҰ����� Ȯ���Ѵ�.
	�ּҰ��̶�� �ּҰ� ���ÿ��� ��带 �ִ´�. 
*/ 
int push(int InputN, NODE *PEH, NODE *PMH){
	// PUSH ��� 
	NODE *PUSH_NODE;

	PUSH_NODE = (NODE *)malloc(sizeof(NODE));
	
	// �Է� ���� PUSH ����� ���ҷ� �ִ´�. 
	PUSH_NODE->num = InputN;
	// PUSH ��尡 ó�� �־����� ����� ���, �ּҰ� ���ÿ� PUSH ��带 �ִ´�. 
	if (PEH->p_enext == NULL){
		PUSH_NODE->p_mnext = PMH->p_mnext;
		PMH->p_mnext = PUSH_NODE;
	}
	//
	// PUSH ����� ���Ұ� �ּҰ� ������ Top�� ���Һ��� ���� ���, �ּҰ� ���ÿ� PUSH ��带 �ִ´�. 
	else if (PUSH_NODE->num < (PMH->p_mnext)->num){
		PUSH_NODE->p_mnext = PMH->p_mnext;
		PMH->p_mnext = PUSH_NODE;
	}
	//
	// PUSH ��带 ���� ���ÿ� �ִ´�. 
	PUSH_NODE->p_enext = PEH->p_enext;
	PEH->p_enext = PUSH_NODE;
	//

	return PUSH_NODE->num;
}

// pop �Լ� 
/*
	 ���� ���ÿ��� Top ��带 �����Ѵ�.
	 ����, ������ ��尡 �ּҰ� ������ Top ����� �ּҰ� ���ÿ����� �����Ѵ�. 
*/ 
int pop(NODE *PEH, NODE *PMH){
	// POP ����� ���� 
	int POP_N;
	
	// POP ��� 
	NODE *POP_NODE = PEH->p_enext;
	
	// ����, POP ��尡 �ּҰ� ������ Top ����� ���, �ι�° �ּҰ��� ������ ��带 Top���� �����Ѵ�. 
	if (POP_NODE == PMH->p_mnext){
		PMH->p_mnext = POP_NODE->p_mnext;
	}
	//
	// ���� ���ÿ��� POP ��带 �����Ѵ�. 
	PEH->p_enext = POP_NODE->p_enext;
	
	// return �� ���� POP_N �� POP_NODE �� ���Ҹ� �����Ѵ�. 
	POP_N = POP_NODE->num;
	
	// POP_NODE �� ������Ų��. 
	free(POP_NODE);
	
	return POP_N;
}

// findMin �Լ� 
/*
	�ּҰ��� Top ����� ���Ҹ� return �Ѵ�.
*/ 
int findMin(NODE *PMH){
	return (PMH->p_mnext)->num;
}

// pushMillion �Լ� 
/*
	push �Լ��� �鸸�� �ݺ��Ѵ�.
	�Է°��� �������� �ϵ�, ������ 1000 ~ 9999 �̴�.
*/ 
void pushMillion(NODE *PEH, NODE *PMH){
	int i, InputN;

	for (i = 0 ; i < 1000000 ; i++){
		InputN = (rand() % 9000) + 1000;
		push(InputN, PEH, PMH);
	}
}

// popMillion �Լ� 
/*
	pop �Լ��� �鸸�� �ݺ��Ѵ�.
*/ 
void popMillion(NODE *PEH, NODE *PMH){
	int i;

	for (i = 0 ; i < 1000000 ; i++){
		pop(PEH, PMH);
	}
}

// DeleteAll �Լ� 
/*
	���α׷� ���� ���� �� ������ ��� ��带 ���� �Ѵ�. 
*/
void DeleteAll(NODE *PEH, NODE *PMH){
	NODE *POP_NODE;

	while (PEH->p_enext != NULL){
		POP_NODE = PEH->p_enext;
		if (POP_NODE == PMH->p_mnext){
			PMH->p_mnext = POP_NODE->p_mnext;
		}
		PEH->p_enext = POP_NODE->p_enext;

		free(POP_NODE);
	}
	free(PEH);
	free(PMH); 
}

// main �Լ� 
int main(){
	char order;
	int N = 0, InputN, PUSH_N, POP_N, Min;
	// ���� CPU ���� �ð� 
	double CpuTime;
	
	// ���� ������ ����� �ּҰ� ������ ��� 
	NODE *PEH, *PMH;
	
	// CPU ���� �ð��� �����ϱ� ���� �ʿ��� ���� 
	__int64 Frequency, BeginTime, EndTime, elapsed;
	
	QueryPerformanceFrequency(&Frequency);

	PEH = (NODE *)malloc(sizeof(NODE));
	PMH = (NODE *)malloc(sizeof(NODE));

	PEH->p_enext = NULL;
	PEH->p_mnext = NULL;

	PMH->p_enext = NULL;
	PMH->p_mnext = NULL;

	do {
		scanf("%c", &order);
		switch (order){
		// push
		case 'p' :
			scanf("%d", &InputN);
			
			QueryPerformanceCounter((LARGE_INTEGER *)&BeginTime); 
			
			PUSH_N = push(InputN, PEH, PMH);
			
			QueryPerformanceCounter((LARGE_INTEGER *)&EndTime);
			elapsed = EndTime - BeginTime;
			CpuTime = (double)elapsed / Frequency;
			
			N++;
			
			printf("push %d (%d), cpu time = %lf\n", PUSH_N, N, CpuTime);
			
			break;
		// pop
		case 'o' :
			// ���ÿ� ��尡 �������� ���� ���, ���� ó���Ѵ�. 
			if (N == 0){
				printf("ERROR!!!\n");
			}
			//
			else {
				QueryPerformanceCounter((LARGE_INTEGER *)&BeginTime);
				
				POP_N = pop(PEH, PMH);
				
				QueryPerformanceCounter((LARGE_INTEGER *)&EndTime);
				elapsed = EndTime - BeginTime;
				CpuTime = (double)elapsed / Frequency;
				
				N--;
				
				printf("pop %d (%d), cpu time = %lf\n", POP_N, N, CpuTime);
			}
			break;
		// findMin
		case 'f' :
			// ���ÿ� ��尡 �������� ���� ���, ���� ó���Ѵ�. 
			if (N == 0){
				printf("ERROR!!!\n");
			}
			//
			else {
				QueryPerformanceCounter((LARGE_INTEGER *)&BeginTime);
				
				Min = findMin(PMH);
				
				QueryPerformanceCounter((LARGE_INTEGER *)&EndTime);
				elapsed = EndTime - BeginTime;
				CpuTime = (double)elapsed / Frequency;
				
				printf("min %d (%d), cpu time = %lf\n", Min, N, CpuTime);
			}
			break;
		// pushMillion
		case 'P' :
			QueryPerformanceCounter((LARGE_INTEGER *)&BeginTime);
			
			pushMillion(PEH, PMH);
			
			QueryPerformanceCounter((LARGE_INTEGER *)&EndTime);
			elapsed = EndTime - BeginTime;
			CpuTime = (double)elapsed / Frequency;
			
			N += 1000000;
			
			printf("pushMillion (%d), cpu time = %lf\n", N, CpuTime);
			
			break;
		// popMillion
		case 'O' :
			// ���ÿ� ��尡 �鸸�� �̻� �������� ���� ���, ���� ó���Ѵ�. 
			if (N < 1000000){
				printf("ERROR!!!\n");
			}
			else {
				QueryPerformanceCounter((LARGE_INTEGER *)&BeginTime);
				
				popMillion(PEH, PMH);
				
				QueryPerformanceCounter((LARGE_INTEGER *)&EndTime);
				elapsed = EndTime - BeginTime;
				CpuTime = (double)elapsed / Frequency;
				
				N -= 1000000;
				
				printf("popMillion (%d), cpu time = %lf\n", N, CpuTime);
			}
			break;
		}
	} while (order != 'q');

	DeleteAll(PEH, PMH);

	return 0;
}
