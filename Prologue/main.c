//
// Created by 15719 on 2024/10/28.
//
#include <math.h>
#include <stdio.h>

typedef struct {
    double x;
    double y;
    double r;
} Circle;

void InitCircle(Circle *c, double x, double y, double r)
{
    c -> r = r;
    c -> x = x;
    c -> y = y;
}

double Area(Circle *c)
{
    return M_PI * c -> r * c -> r;
}

double Circumference(Circle *c)
{
    return 2 * M_PI * c-> r;
}

int main()
{
    Circle c;
    InitCircle(&c, 5, 5, 5); // 用 & 避免c中结构体传参时会重新复制一份，并且只在函数内进行修改值
    printf("圆的面积: %.2f\n", Area(&c));
    printf("圆的周长: %.2f\n", Circumference(&c));
    return 0;
}