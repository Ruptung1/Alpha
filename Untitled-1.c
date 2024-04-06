#include<stdio.h>
int main()
{
    int nums[9][9]={};
    int i,k,m,n;
    int count =0, X, Y;
    int numprint[9][9]={
        {0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0},
        {0,0,0,0,0,0,0,0,0,0}
    }
    for (int m=0; m<=9; m++)   
    {
        for (int n=0; n<=9; n++)    
        {
            printf("%d ", numprint[m][n]); 
        }
        printf("\n");
    }
    for(i=0;i<9;i++)
     {
         for(k=0;k<9;i++)
         { 
            scanf("%d",&num[i][k]); //지뢰 인지 아닌지 지정
         }
     }

    scanf("%d %d",&X,&Y); //내가 확인해볼 칸 설정

    if(num[X][Y]==1)
    {
        printf("game over");
        break;
    }
    else{

        for(int i=X-1,i<=X+1;i++)
        {
            for(int k=Y-1;k<=Y+1;k++)
            {
                if(num[i][k]==1)
                {
                    count++
                }
            }
        }
        numprint[X][Y] = count;
        
        //내가 선택한 칸 주위의 지뢰 개수 출력, 
        for (int m=0; m<=9; m++)   
        {
         for (int n=0; n<=9; n++)    
        {
            printf("%d ", numprint[m][n]); 
         }
        printf("\n");
        }
}
