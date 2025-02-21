﻿using System;
using System.Windows;
using System.Windows.Controls;

namespace Lab3
{
    public partial class MainWindow : Window
    {
        private int initialX = 150;
        private int initialY = 100;
        private int currentX;
        private int currentY;

        public MainWindow()
        {
            InitializeComponent();
            currentX = initialX;
            currentY = initialY;
            UpdateButtonStates();
        }

        private void MovePoint(int deltaX, int deltaY)
        {
            int newX = currentX + deltaX;
            int newY = currentY + deltaY;

            // Проверяем, чтобы точка не выходила за границы окна
            if (newX >= 0 && newX <= (int)Width - PointLabel.ActualWidth &&
                newY >= 0 && newY <= (int)Height - PointLabel.ActualHeight)
            {
                currentX = newX;
                currentY = newY;
                PointLabel.Margin = new Thickness(currentX, currentY, 0, 0);
            }

            UpdateButtonStates();
        }

        private void UpdateButtonStates()
        {
            UpButton.IsEnabled = currentY > 0;
            DownButton.IsEnabled = currentY < (int)Height - PointLabel.ActualHeight;
            LeftButton.IsEnabled = currentX > 0;
            RightButton.IsEnabled = currentX < (int)Width - PointLabel.ActualWidth;
        }

        private void UpButton_Click(object sender, RoutedEventArgs e)
        {
            MovePoint(0, -10);
        }

        private void DownButton_Click(object sender, RoutedEventArgs e)
        {
            MovePoint(0, 10);
        }

        private void LeftButton_Click(object sender, RoutedEventArgs e)
        {
            MovePoint(-10, 0);
        }

        private void RightButton_Click(object sender, RoutedEventArgs e)
        {
            MovePoint(10, 0);
        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            int deviationX = currentX - initialX;
            int deviationY = currentY - initialY;
            string message = $"Положение ({currentX};{currentY}) Отклонение ({deviationX};{deviationY})";
            MessageBox.Show(message, "Информация о положении точки");
        }
    }
}