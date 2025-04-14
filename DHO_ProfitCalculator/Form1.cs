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
            buttonCalculateProductSales.Click += buttonCalculateProductSales_Click;
        }

        private void buttonCalculate_Click(object? sender, EventArgs e)
        {
            try
            {
                // null �Ǵ� ����ִ� �ؽ�Ʈ�ڽ��� 0���� ó��
                double price1 = string.IsNullOrWhiteSpace(textBox1.Text) ? 0 : Convert.ToDouble(textBox1.Text);
                int quantity1 = string.IsNullOrWhiteSpace(textBox2.Text) ? 0 : Convert.ToInt32(textBox2.Text);
                double totalCost1 = price1 * quantity1;
                textBox4.Text = totalCost1.ToString("F2");

                // 2�� ���ּ�
                double price2 = string.IsNullOrWhiteSpace(textBox5.Text) ? 0 : Convert.ToDouble(textBox5.Text);
                int quantity2 = string.IsNullOrWhiteSpace(textBox6.Text) ? 0 : Convert.ToInt32(textBox6.Text);
                double totalCost2 = price2 * quantity2;
                textBox8.Text = totalCost2.ToString("F2");

                // 3�� ���ּ�
                double price3 = string.IsNullOrWhiteSpace(textBox9.Text) ? 0 : Convert.ToDouble(textBox9.Text);
                int quantity3 = string.IsNullOrWhiteSpace(textBox10.Text) ? 0 : Convert.ToInt32(textBox10.Text);
                double totalCost3 = price3 * quantity3;
                textBox12.Text = totalCost3.ToString("F2");

                // 4�� ���ּ�
                double price4 = string.IsNullOrWhiteSpace(textBox13.Text) ? 0 : Convert.ToDouble(textBox13.Text);
                int quantity4 = string.IsNullOrWhiteSpace(textBox14.Text) ? 0 : Convert.ToInt32(textBox14.Text);
                double totalCost4 = price4 * quantity4;
                textBox16.Text = totalCost4.ToString("F2");
            }
            catch (FormatException)
            {
                MessageBox.Show("�ùٸ� ���ڸ� �Է����ּ���!", "�Է� ����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                label22.Text = $"��� �� ���: {totalMaterialCost:F2}��ı";
            }
            catch (FormatException)
            {
                MessageBox.Show("�ùٸ� ���ڸ� �Է����ּ���!", "�Է� ����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void buttonCalculateTotal_Click(object? sender, EventArgs e)
        {
            try
            {
                // ���ּ� �� ��� ���
                double totalOrderCost = (string.IsNullOrWhiteSpace(textBox4.Text) ? 0 : Convert.ToDouble(textBox4.Text)) +
                                        (string.IsNullOrWhiteSpace(textBox8.Text) ? 0 : Convert.ToDouble(textBox8.Text)) +
                                        (string.IsNullOrWhiteSpace(textBox12.Text) ? 0 : Convert.ToDouble(textBox12.Text)) +
                                        (string.IsNullOrWhiteSpace(textBox16.Text) ? 0 : Convert.ToDouble(textBox16.Text));

                // ��� �� ��� ���
                double totalMaterialCost = (string.IsNullOrWhiteSpace(textBox23.Text) ? 0 : Convert.ToDouble(textBox23.Text)) +
                                           (string.IsNullOrWhiteSpace(textBox24.Text) ? 0 : Convert.ToDouble(textBox24.Text)) +
                                           (string.IsNullOrWhiteSpace(textBox25.Text) ? 0 : Convert.ToDouble(textBox25.Text));

                // ���� �� ��� ���
                double grandTotal = totalOrderCost + totalMaterialCost;

                // ��� ���
                MessageBox.Show($"���ּ� �� ���: {totalOrderCost:F2}��ı\n��� �� ���: {totalMaterialCost:F2}��ı\n���� �� ���: {grandTotal:F2}��ı",
                                "���� ���", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (FormatException)
            {
                MessageBox.Show("�ùٸ� ���ڸ� �Է����ּ���!", "�Է� ����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        // KeyDown �̺�Ʈ �ڵ鷯
        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                // F2: ���ּ� ���
                buttonCalculate_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F3)
            {
                // F3: ��ᰪ ���
                buttonCalculateMaterials_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F4)
            {
                // F3: ��ᰪ ���
                buttonCalculateProductSales_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F5)
            {
                // F4: ��� ���
                buttonCalculateTotal_Click(sender, e);
            }
        }
        private void buttonCalculateProductSales_Click(object? sender, EventArgs e)
        {
            try
            {
                // ��� ��뷮
                double material1Used = string.IsNullOrWhiteSpace(textBox3.Text) ? 0 : Convert.ToDouble(textBox3.Text);
                double material2Used = string.IsNullOrWhiteSpace(textBox7.Text) ? 0 : Convert.ToDouble(textBox7.Text);
                double material3Used = string.IsNullOrWhiteSpace(textBox11.Text) ? 0 : Convert.ToDouble(textBox11.Text);

                // �ʿ��� ��� ��
                double requiredMaterial1 = string.IsNullOrWhiteSpace(textBox17.Text) ? 1 : Convert.ToDouble(textBox17.Text);
                double requiredMaterial2 = string.IsNullOrWhiteSpace(textBox18.Text) ? 1 : Convert.ToDouble(textBox18.Text);
                double requiredMaterial3 = string.IsNullOrWhiteSpace(textBox19.Text) ? 1 : Convert.ToDouble(textBox19.Text);

                // �ʿ� ������ 0�� ��� ����
                if (requiredMaterial1 <= 0 || requiredMaterial2 <= 0 || (checkBoxUseMaterial3.Checked && requiredMaterial3 <= 0))
                {
                    MessageBox.Show("�ʿ� ��� ������ 0���� Ŀ�� �մϴ�!", "�Է� ����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ���� ���� ���� ���
                double count1 = requiredMaterial1 / material1Used;
                double count2 = requiredMaterial2 / material2Used;
                double count3 = checkBoxUseMaterial3.Checked ? requiredMaterial3/ material3Used : double.MaxValue;

                int estimatedProducts = (int)Math.Floor(Math.Min(count1, Math.Min(count2, count3)));

                // �뼺�� �ùķ��̼�
                Random random = new Random();
                int successCount = 0;
                for (int i = 0; i < estimatedProducts; i++)
                {
                    if (random.NextDouble() <= 0.2)
                    {
                        successCount++;
                    }
                }

                int totalProducts = estimatedProducts + successCount;

                // ���� ���� ���
                double pricePerProduct = string.IsNullOrWhiteSpace(textBox26.Text) ? 0 : Convert.ToDouble(textBox26.Text);
                double totalRevenue = totalProducts * pricePerProduct; // ���� ���͸�

                // ��� ���
                textBox15.Text = totalProducts.ToString();     // �뼺�� ���Ե� �� ���� ����
                textBox27.Text = totalRevenue.ToString("F2");  // ���� �� ����
            }
            catch (FormatException)
            {
                MessageBox.Show("�ùٸ� ���� �Է����ּ���!", "�Է� ����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
