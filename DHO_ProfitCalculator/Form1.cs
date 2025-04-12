using System;
using System.Windows.Forms;

namespace DHO_ProfitCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;

            buttonCalculateOrders.Click += buttonCalculate_Click;
            buttonCalculateMaterials.Click += buttonCalculateMaterials_Click;
            buttonCalculateTotal.Click += buttonCalculateTotal_Click;


        }

        private void buttonCalculate_Click(object? sender, EventArgs e)
        {
            try
            {
                // null 또는 비어있는 텍스트박스를 0으로 처리
                double price1 = string.IsNullOrWhiteSpace(textBox1.Text) ? 0 : Convert.ToDouble(textBox1.Text);
                int quantity1 = string.IsNullOrWhiteSpace(textBox2.Text) ? 0 : Convert.ToInt32(textBox2.Text);
                double totalCost1 = price1 * quantity1;
                textBox4.Text = totalCost1.ToString("F2");

                // 2번 발주서
                double price2 = string.IsNullOrWhiteSpace(textBox5.Text) ? 0 : Convert.ToDouble(textBox5.Text);
                int quantity2 = string.IsNullOrWhiteSpace(textBox6.Text) ? 0 : Convert.ToInt32(textBox6.Text);
                double totalCost2 = price2 * quantity2;
                textBox8.Text = totalCost2.ToString("F2");

                // 3번 발주서
                double price3 = string.IsNullOrWhiteSpace(textBox9.Text) ? 0 : Convert.ToDouble(textBox9.Text);
                int quantity3 = string.IsNullOrWhiteSpace(textBox10.Text) ? 0 : Convert.ToInt32(textBox10.Text);
                double totalCost3 = price3 * quantity3;
                textBox12.Text = totalCost3.ToString("F2");

                // 4번 발주서
                double price4 = string.IsNullOrWhiteSpace(textBox13.Text) ? 0 : Convert.ToDouble(textBox13.Text);
                int quantity4 = string.IsNullOrWhiteSpace(textBox14.Text) ? 0 : Convert.ToInt32(textBox14.Text);
                double totalCost4 = price4 * quantity4;
                textBox16.Text = totalCost4.ToString("F2");
            }
            catch (FormatException)
            {
                MessageBox.Show("올바른 숫자를 입력해주세요!", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void buttonCalculateMaterials_Click(object? sender, EventArgs e)
        {
            try
            {
                double materialCost1 = (string.IsNullOrWhiteSpace(textBox17.Text) ? 0 : Convert.ToDouble(textBox17.Text)) *
                                       (string.IsNullOrWhiteSpace(textBox20.Text) ? 0 : Convert.ToDouble(textBox20.Text));
                double materialCost2 = (string.IsNullOrWhiteSpace(textBox18.Text) ? 0 : Convert.ToDouble(textBox18.Text)) *
                                       (string.IsNullOrWhiteSpace(textBox21.Text) ? 0 : Convert.ToDouble(textBox21.Text));
                double materialCost3 = (string.IsNullOrWhiteSpace(textBox19.Text) ? 0 : Convert.ToDouble(textBox19.Text)) *
                                       (string.IsNullOrWhiteSpace(textBox22.Text) ? 0 : Convert.ToDouble(textBox22.Text));

                textBox23.Text = materialCost1.ToString("F2");
                textBox24.Text = materialCost2.ToString("F2");
                textBox25.Text = materialCost3.ToString("F2");

                double totalMaterialCost = materialCost1 + materialCost2 + materialCost3;
                label22.Text = $"재료 총 비용: {totalMaterialCost:F2}두캇";
            }
            catch (FormatException)
            {
                MessageBox.Show("올바른 숫자를 입력해주세요!", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void buttonCalculateTotal_Click(object? sender, EventArgs e)
        {
            try
            {
                // 발주서 총 비용 계산
                double totalOrderCost = (string.IsNullOrWhiteSpace(textBox4.Text) ? 0 : Convert.ToDouble(textBox4.Text)) +
                                        (string.IsNullOrWhiteSpace(textBox8.Text) ? 0 : Convert.ToDouble(textBox8.Text)) +
                                        (string.IsNullOrWhiteSpace(textBox12.Text) ? 0 : Convert.ToDouble(textBox12.Text)) +
                                        (string.IsNullOrWhiteSpace(textBox16.Text) ? 0 : Convert.ToDouble(textBox16.Text));

                // 재료 총 비용 계산
                double totalMaterialCost = (string.IsNullOrWhiteSpace(textBox23.Text) ? 0 : Convert.ToDouble(textBox23.Text)) +
                                           (string.IsNullOrWhiteSpace(textBox24.Text) ? 0 : Convert.ToDouble(textBox24.Text)) +
                                           (string.IsNullOrWhiteSpace(textBox25.Text) ? 0 : Convert.ToDouble(textBox25.Text));

                // 최종 총 비용 계산
                double grandTotal = totalOrderCost + totalMaterialCost;

                // 결과 출력
                MessageBox.Show($"발주서 총 비용: {totalOrderCost:F2}두캇\n재료 총 비용: {totalMaterialCost:F2}두캇\n최종 총 비용: {grandTotal:F2}두캇",
                                "총합 결과", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (FormatException)
            {
                MessageBox.Show("올바른 숫자를 입력해주세요!", "입력 오류", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        // KeyDown 이벤트 핸들러
        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                // F2: 발주서 계산
                buttonCalculate_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F3)
            {
                // F3: 재료값 계산
                buttonCalculateMaterials_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F4)
            {
                // F4: 비용 계산
                buttonCalculateTotal_Click(sender, e);
            }
        }

    }
}
