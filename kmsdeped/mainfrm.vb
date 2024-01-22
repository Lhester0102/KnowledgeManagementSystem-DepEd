Public Class mainfrm

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub ElemenaryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ElemenaryToolStripMenuItem.Click
        With enrollment_elementary
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub HighschoolToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HighschoolToolStripMenuItem.Click
        With enrollment_highschool
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub TeachersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TeachersToolStripMenuItem.Click
        With teachers
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub RoomToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RoomToolStripMenuItem.Click

    End Sub

    Private Sub InstructionalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InstructionalToolStripMenuItem.Click
        With rooms_i
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub NonInstructionalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NonInstructionalToolStripMenuItem.Click
        With rooms_ni
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub WaterSupplyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WaterSupplyToolStripMenuItem.Click
        With water
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub ElectricitySupplyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ElectricitySupplyToolStripMenuItem.Click
        With electricity
            .MdiParent = Me
            .Show()
        End With
    End Sub


    Private Sub EnrolleesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EnrolleesToolStripMenuItem1.Click

    End Sub

    Private Sub TeachersToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles TeachersToolStripMenuItem1.Click
  
    End Sub

    Private Sub MOOEToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles MOOEToolStripMenuItem1.Click
 
    End Sub

    Private Sub MOOEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MOOEToolStripMenuItem.Click
        With mooe
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub RoomsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RoomsToolStripMenuItem.Click
        With graph_rooms
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub ElectricitySupplyToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ElectricitySupplyToolStripMenuItem1.Click

    End Sub

    Private Sub WaterSupplyToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles WaterSupplyToolStripMenuItem1.Click

    End Sub

    Private Sub RegionsToolStripMenuItem_Click(sender As Object, e As EventArgs)
        With line_graphs
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub YearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles YearToolStripMenuItem.Click
        With graphs
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub EnrollmentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnrollmentToolStripMenuItem.Click
        With Numeric_Enrollment
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub AllByYearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllByYearToolStripMenuItem.Click
        With all_graphs
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub ElementaryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ElementaryToolStripMenuItem.Click
        With s_ernrollment_es
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub HighschoolToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles HighschoolToolStripMenuItem1.Click
        With s_enrollment_ss
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub ELEMToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ELEMToolStripMenuItem.Click
        With s_mooe
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub HIGHSCHOOLToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles HIGHSCHOOLToolStripMenuItem2.Click
        With s_mooe_h
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub AllRegionByYearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllRegionByYearToolStripMenuItem.Click
        With graph_mooe
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub AllByRegionAndYearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllByRegionAndYearToolStripMenuItem.Click
        With graph_teachers
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub ELEMENTARYToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ELEMENTARYToolStripMenuItem1.Click
        With s_teachers
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub HIGHSCHOOLToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles HIGHSCHOOLToolStripMenuItem3.Click
        With s_teachers_h
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub AllByRegionAndYearToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AllByRegionAndYearToolStripMenuItem1.Click
        With graph_water
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub AllByRegionAndYearToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles AllByRegionAndYearToolStripMenuItem2.Click
        With graph_electricity
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub ELEMENTARYToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ELEMENTARYToolStripMenuItem2.Click
        With s_water
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub HIGHSCHOOLToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles HIGHSCHOOLToolStripMenuItem4.Click
        With s_water_h
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub ElementayToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ElementayToolStripMenuItem.Click
        With s_electricity
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub HighschoolToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles HighschoolToolStripMenuItem5.Click
        With S_electricity_h
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub mainfrm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NumericalToolStripMenuItem.Visible = False
    End Sub

    Private Sub PieGraphOfTeachersByRegionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PieGraphOfTeachersByRegionToolStripMenuItem.Click
        With teacher_pie
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub PieGraphOfEnrollessByRegionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PieGraphOfEnrollessByRegionToolStripMenuItem.Click
        With enrolment_pie
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub PieGraphOfEnrollessToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PieGraphOfEnrollessToolStripMenuItem.Click
        With mooe_pie
            .MdiParent = Me
            .Show()
        End With
    End Sub
End Class