Public Class frmCurrencyConverter

   
    Private Sub frmCurrencyConverter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Add Items to the combo box
        'Select the first item in the combo box
        cboCurrency.Items.Add("Choose a Currency")
        cboCurrency.Items.Add("United kingdom Pound - GBP")
        cboCurrency.Items.Add("Euro - EUR")
        cboCurrency.Items.Add("Russian Rubles - RUB")

    End Sub

    Private Sub cboCurrency_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCurrency.SelectedIndexChanged
        'Set properties for amount textbox when value in the currency combo box
        lblDisplay.Text = " "
        txtAmount.Focus()
    End Sub

    Private Function DoConversion(ByVal decDAmount As Decimal,
                                   ByVal decDExchangeRate As Decimal) As Decimal
        'Convert to desird currency
        Dim decConvertedAmount As Decimal
        decConvertedAmount = decDAmount * decDExchangeRate

        Return decConvertedAmount
    End Function

    Private Sub btnConvert_Click(sender As Object, e As EventArgs) Handles btnConvert.Click
        'Calculate and Display the converted Amount
        Dim decExchangeRate As Decimal = 0
        Dim decAmount As Decimal = 0
        Dim decConvertedAmount As Decimal = 0
        Dim strCurrency As String

        'Check that curreny is selected in the combo box
        If cboCurrency.SelectedIndex = 0 Then
            MessageBox.Show("Select a currency to convert to", " Invalid currency")
            cboCurrency.DroppedDown = True
            Exit Sub
        End If

        'Assign exchange rate to decimal variable
        'Assign GBP, EUR or RUB to a string variable
        If cboCurrency.SelectedIndex = 1 Then
            decExchangeRate = 0.0874832D
            strCurrency = "GBP"
        End If
        If cboCurrency.SelectedIndex = 2 Then
            decExchangeRate = 0.105135D
            strCurrency = "EUR"
        End If
        If cboCurrency.SelectedIndex = 3 Then
            decExchangeRate = 4.15483D
            strCurrency = "RUB"
        End If

        'Check that the Amount TextBox isn't Empty
        If txtAmount.Text = " " Then
            MessageBox.Show("Enter an amount to convert", " Entry error")
            txtAmount.Clear()
            txtAmount.Focus()
            Exit Sub
        End If

        'Test for valid numeric input in the amount textbox
        'Convert and assign value to decimal variable
        If IsNumeric(txtAmount.Text) Then
            decAmount = CDec(txtAmount.Text)
        Else
            MessageBox.Show("Enter a valid amount to convert", " Entry error")
            txtAmount.Clear()
            txtAmount.Focus()
            Exit Sub
        End If

        'Amount entered must be greater than 0
        If Not (decAmount > 0) Then
            MessageBox.Show("Enter a positive Amount", " Entry error")
            txtAmount.Focus()
            txtAmount.Clear()
            Exit Sub
        End If

        'Assing converterd amount to decimal variable
        'Call function to do conversion
        decConvertedAmount = DoConversion(decAmount, decExchangeRate)


        'Display output in label
        lblDisplay.Text = decAmount.ToString("N2") & " ZAR = " & " " &
            decConvertedAmount.ToString("N2") & strCurrency

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        'Clear all controls and set properties
        cboCurrency.SelectedIndex = 1
        txtAmount.Clear()
        lblDisplay.Text = ""
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        'Terminate program
        Me.Close()

    End Sub
End Class
