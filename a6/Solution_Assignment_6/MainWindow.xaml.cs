
/*
Lukas Jönsson
17/04-2024
*/

using Microsoft.Win32;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Input;
namespace Solution_Assignment_6;


/// <summary>
/// MainWindow class
/// </summary>
public partial class MainWindow : Window
{
    /// <summary>
    /// Private attribute
    /// </summary>
    private Invoice invoice;

    /// <summary>
    /// Constructor
    /// </summary>
    public MainWindow()
    {
        InitializeComponent();
        InitializeInterface();
    }

    /// <summary>
    /// Initialize output elements
    /// </summary>
    private void InitializeInterface()
    {
        menuFile.Header = "File";
        menuOpen.Header = "Open";
        menuSave.Header = "Save";
        menuExit.Header = "Exit";
        menuHelp.Header = "Help";

        invoiceDiscountTextBox.Text = string.Empty;

        invoiceGrid.Visibility = Visibility.Hidden;
    }

    /// <summary>
    /// Initialize output elements on file open
    /// </summary>
    private void InitializeOutputElementsOnOpen()
    {
        // Number, Date and Due Date
        invoiceNumberLabel.Content = "Invoice Number";
        invoiceDateLabel.Content = "Invoice Date";
        invoiceDueDateLabel.Content = "Due Date";

        // Receiver
        invoiceReceiverLabel.Content = "Receiver";
        invoiceReceiver.Content = invoice.Receiver;
        invoiceReceiverAddressLabel.Content = "Address";
        invoiceReceiverAddress.Content = $"{invoice.ReceiverAddress.Street} {invoice.ReceiverAddress.Zipcode}, {invoice.ReceiverAddress.City}, {invoice.ReceiverAddress.Country}";

        // Sender
        invoiceSender.Content = invoice.Sender;
        invoiceSenderAddressLabel.Content = "Address";
        invoiceSenderAddressSender.Content = invoice.Sender;
        invoiceSenderAddressStreet.Content = invoice.ReceiverAddress.Street;
        invoiceSenderAddressZipcodeCity.Content = $"{invoice.ReceiverAddress.Zipcode}, {invoice.ReceiverAddress.City}";
        invoiceSenderAddressCountry.Content = invoice.ReceiverAddress.Country;
        invoiceSenderContactLabel.Content = "Contact";
        invoiceSenderContactPhone.Content = invoice.SenderPhone;
        invoiceSenderContactURL.Content = invoice.SenderURL;

        // Products
        invoiceListViewName.Header = "Name";
        invoiceListViewQuantity.Header = "Quantity";
        invoiceListViewPrice.Header = "Price ($)";
        invoiceListViewTax.Header = "Tax (%)";
        invoiceListViewTotalTax.Header = "Total Tax ($)";
        invoiceListViewTotalPrice.Header = "Total Price ($)";
        invoiceListView.ItemsSource = invoice.Products;

        // Discount and Total
        invoiceDiscountLabel.Content = "Discount";
        invoiceTotalLabel.Content = "Total";
        invoiceTotal.Content = invoice.TotalPriceWithDiscount.ToString();

        invoiceGrid.Visibility = Visibility.Visible;
    }

    /// <summary>
    /// Initialize input elements on file open
    /// </summary>
    private void InitializeInputElementsOnOpen()
    {
        invoiceNumberTextBox.Text = invoice.NumDate.Item1;
        invoiceDate.SelectedDate = invoice.NumDate.Item2;
        invoiceDueDate.SelectedDate = invoice.NumDate.Item3;
        invoiceDiscountTextBox.Text = invoice.Discount.ToString();
    }

    /// <summary>
    /// Initialize elements on file open and attach the event handlers
    /// </summary>
    private void InitializeElementsOnOpen()
    {
        InitializeOutputElementsOnOpen();
        InitializeInputElementsOnOpen();
        invoiceDate.SelectedDateChanged += HandleInvoiceDate;
        invoiceDueDate.SelectedDateChanged += HandleInvoiceDueDate;
    }

    /// <summary>
    /// Validate data type of int
    /// </summary>
    /// <param name="data">String</param>
    /// <returns>True if int, otherwise false</returns>
    private bool ValidateInt(string data)
    {
        int validDataType;
        return int.TryParse(data.Trim(), out validDataType);
    }

    /// <summary>
    /// Validate data type of double
    /// </summary>
    /// <param name="data">String</param>
    /// <returns>True if double, otherwise false</returns>
    private bool ValidateDouble(string data)
    {
        double validDataType;
        return double.TryParse(data.Trim(), out validDataType);
    }

    /// <summary>
    /// Parse double and ensure that both "." and "," are readable 
    /// </summary>
    /// <param name="data">String</param>
    /// <returns>Double</returns>
    private double ParseDouble(string data)
    {
        return double.Parse(data.Trim(), CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Parse double to string and ensure that both "." and "," are readable 
    /// </summary>
    /// <param name="data">Double</param>
    /// <returns>String</returns>
    private string ParseDoubleToString(double data)
    {
        return data.ToString(CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Handle open invoice
    /// </summary>
    /// <param name="sender">Object that invoked the event</param>
    /// <param name="e">Event data</param>
    private void HandleOpenInvoice(object sender, EventArgs e)
    {
        try
        {
            OpenFileDialog fileOpen = new OpenFileDialog();
            bool? fileIsOpened = fileOpen.ShowDialog();

            if (fileIsOpened == true)
            {
                string filename = fileOpen.FileName;
                string[] data = File.ReadAllLines(filename);

                // Validate that the number of products is at the specific index
                if (!ValidateInt(data[16]))
                {
                    MessageBox.Show($"Could not open file...");
                }
                else
                {
                    invoice = new Invoice();
                    invoice.NumDate = Tuple.Create(data[0], DateTime.Parse(data[1]), DateTime.Parse(data[2]));
                    invoice.Receiver = data[3];
                    invoice.ReceiverAddress = new Address(data[4], data[5], data[6], data[7]);
                    invoice.Sender = data[8];
                    invoice.SenderAddress = new Address(data[9], data[10], data[1], data[12]);
                    invoice.SenderPhone = data[13];
                    invoice.SenderURL = data[14];
                    invoice.Discount = ParseDouble(data[15]);

                    int numberOfProducts = int.Parse(data[16]);

                    for (int index = 0; index < numberOfProducts; index++)
                    {
                        // Each product is represented in four rows in Name, Quantity, Price and Tax
                        int productIndex = 17 + (index * 4);

                        Product product = new Product
                        {
                            Name = data[productIndex],
                            Quantity = int.Parse(data[productIndex + 1]),
                            Price = ParseDouble(data[productIndex + 2]),
                            Tax = ParseDouble(data[productIndex + 3]),
                        };
                        invoice.Products.Add(product);
                    }
                }
                InitializeElementsOnOpen();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Could not open file...{ex.Message}");
        }
    }

    /// <summary>
    /// Handle change of invoice date
    /// </summary>
    /// <param name="sender">Object that invoked the event</param>
    /// <param name="e">Event data</param>
    private void HandleInvoiceDate(object? sender, EventArgs e)
    {
        if (invoice != null)
        {
            invoice.NumDate = Tuple.Create(invoice.NumDate.Item1, invoiceDate.SelectedDate.GetValueOrDefault().Date, invoice.NumDate.Item3);
        }
    }

    /// <summary>
    /// Handle change of invoice due date
    /// </summary>
    /// <param name="sender">Object that invoked the event</param>
    /// <param name="e">Event data</param>
    private void HandleInvoiceDueDate(object? sender, EventArgs e)
    {
        if (invoice != null)
        {
            invoice.NumDate = Tuple.Create(invoice.NumDate.Item1, invoice.NumDate.Item2, invoiceDueDate.SelectedDate.GetValueOrDefault().Date);
        }
    }

    /// <summary>
    /// Handle change of invoice number
    /// </summary>
    /// <param name="sender">Object that invoked the event</param>
    /// <param name="e">Event data</param>
    private void HandleInvoiceNumber(object sender, KeyEventArgs e)
    {
        if (invoiceNumberTextBox.Text.Length > 0)
        {
            if (invoice != null)
            {
                invoice.NumDate = Tuple.Create(invoiceNumberTextBox.Text.Trim(), invoice.NumDate.Item2, invoice.NumDate.Item3);
            }
        }
        else
        {
            MessageBox.Show("Please enter invoice number!");
        }
    }

    /// <summary>
    /// Handle change of invoice discount
    /// </summary>
    /// <param name="sender">Object that invoked the event</param>
    /// <param name="e">Event data</param>
    private void HandleInvoiceDiscount(object sender, KeyEventArgs e)
    {
        // Set discount after press enter and validation of the discount (the discount can only be set once)
        if (e.Key == Key.Enter)
        {
            if (ValidateDouble(invoiceDiscountTextBox.Text))
            {
                if (invoice.Discount == 0)
                {
                    invoice.Discount = double.Parse(invoiceDiscountTextBox.Text);
                    InitializeElementsOnOpen();
                }
                else
                {
                    MessageBox.Show("The discount code has already been applied!");
                }
            }
            else
            {
                MessageBox.Show("Please enter valid discount!");
            }
        }
    }

    /// <summary>
    /// Handle save invoice
    /// </summary>
    /// <param name="sender">Object that invoked the event</param>
    /// <param name="e">Event data</param>
    private void HandleSaveInvoice(object sender, EventArgs e)
    {
        try
        {
            if (invoice != null)
            {
                SaveFileDialog fileSave = new SaveFileDialog();
                fileSave.FileName = $"{invoice.NumDate.Item1}.txt";

                if (fileSave.ShowDialog() == true)
                {

                    File.WriteAllText(fileSave.FileName, string.Empty);

                    using (StreamWriter writer = new StreamWriter(fileSave.FileName, true))
                    {
                        writer.WriteLine(invoice.NumDate.Item1);
                        writer.WriteLine(invoice.NumDate.Item2);
                        writer.WriteLine(invoice.NumDate.Item3);
                        writer.WriteLine(invoice.Receiver);
                        writer.WriteLine(invoice.ReceiverAddress.Street);
                        writer.WriteLine(invoice.ReceiverAddress.Zipcode);
                        writer.WriteLine(invoice.ReceiverAddress.City);
                        writer.WriteLine(invoice.ReceiverAddress.Country);
                        writer.WriteLine(invoice.Sender);
                        writer.WriteLine(invoice.SenderAddress.Street);
                        writer.WriteLine(invoice.SenderAddress.Zipcode);
                        writer.WriteLine(invoice.SenderAddress.City);
                        writer.WriteLine(invoice.SenderAddress.Country);
                        writer.WriteLine(invoice.SenderPhone);
                        writer.WriteLine(invoice.SenderURL);
                        writer.WriteLine(ParseDoubleToString(invoice.Discount));
                        writer.WriteLine(invoice.Products.Count);

                        foreach (Product product in invoice.Products)
                        {
                            writer.WriteLine(product.Name);
                            writer.WriteLine(product.Quantity);
                            writer.WriteLine(ParseDoubleToString(product.Price));
                            writer.WriteLine(ParseDoubleToString(product.Tax));
                        }
                    }
                    MessageBox.Show($"Successfully saved invoice - {invoice.NumDate.Item1}");
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Could not save invoice...{ex.Message}");
        }
    }

    /// <summary>
    /// Handle exit
    /// </summary>
    /// <param name="sender">Object that invoked the event</param>
    /// <param name="e">Event data</param>
    private void HandleExit(object sender, EventArgs e)
    {
        Application.Current.Shutdown();
    }
}