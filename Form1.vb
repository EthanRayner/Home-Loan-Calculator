Public Class Form1
    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        'Calculate home loan information using the inputs.

        Dim existingMortgage As Integer = Val(txtMortgage.Text)
        Dim priceOldHome As Integer = Val(txtOldHome.Text)
        Dim priceNewHome As Integer = Val(txtNewHome.Text)

        'Output variables
        'agents commision, deposit for New home and stamp duty
        Dim agentCommission As Integer
        Dim newDeposit As Integer
        Dim StampDuty As Integer
        Dim NewMortgage As Integer
        Dim passvalidation As Boolean = False

        If Not IsNumeric(txtMortgage.Text) Or Not IsNumeric(txtNewHome.Text) Or Not IsNumeric(txtOldHome.Text) Then
            MsgBox("Please input a numerical value.")
        ElseIf (Val(existingMortgage) < 0) Or (val(priceOldHome) < 0) Or (Val(priceNewHome) < 0) Then
            MsgBox("Please input a positive value.")
        Else
            passvalidation = True
        End If



        If passvalidation = True Then

            'calculation
            agentCommission = priceOldHome * 2.5 / 100
        newDeposit = priceOldHome - existingMortgage - agentCommission
        StampDuty = 0.03 * (priceNewHome - newDeposit)
        NewMortgage = (priceNewHome - newDeposit) + StampDuty

        'Outputs
        txtStampDuty.Text = Str(StampDuty)
        txtCommission.Text = Str(agentCommission)
        txtDeposit.Text = Str(newDeposit)

            'Checking for government approval
            If NewMortgage / priceNewHome < 0.8 Then
                MsgBox("Loan Approved" + vbNewLine + vbNewLine + "New Mortgage is:" + Str(NewMortgage))
            Else
                MsgBox("Loan Denied")
            End If

        End If

    End Sub
End Class
