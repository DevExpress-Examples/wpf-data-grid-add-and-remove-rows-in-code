<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/176968018/19.1.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T830446)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# WPF Data Grid - Add and Remove Rows in Code

This example demonstrates how to define an **AddRemoveRowBehavior** that allows you to add and remove rows from the [GridControl](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridControl). The behavior uses the [TableView.AddNewRow](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.TableView.AddNewRow(System.Boolean)) and [GridViewBase.DeleteRow](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridViewBase.DeleteRow(System.Int32)) methods to add and remove rows, and the [TableView.InitNewRow](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.TableView.InitNewRow) event to populate the added row with default values.

![image](https://user-images.githubusercontent.com/65009440/175929544-6fc4e5c4-3225-4a42-8f77-4eca17dc9e00.png)

## Files to Look At

* [MainWindow.xaml](./CS/AddRemoveRows/MainWindow.xaml)
* [AddRemoveRowBehavior.cs](./CS/AddRemoveRows/AddRemoveRowBehavior.cs)

## Documentation

* [Add and Remove Rows](https://docs.devexpress.com/WPF/6123/controls-and-libraries/data-grid/data-editing-and-validation/add-and-remove-rows)
* [TableView.AddNewRow](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.TableView.AddNewRow(System.Boolean))
* [GridViewBase.DeleteRow](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridViewBase.DeleteRow(System.Int32))
* [TableView.InitNewRow](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.TableView.InitNewRow)

## More Examples

* [Implement CRUD Operations in the WPF Data Grid](https://github.com/DevExpress-Examples/how-to-implement-crud-operations)
* [WPF Data Grid - How to Initialize a New Row when the Editor is Shown](https://github.com/DevExpress-Examples/how-to-initialize-a-new-row-when-only-the-editor-is-shown-e1817)
* [WPF Data Grid - How to Initialize the New Item Row with Default Values](https://github.com/DevExpress-Examples/how-to-initialize-the-new-item-row-with-default-values-e1569)
* [WPF Data Grid - How to Validate Data Rows](https://github.com/DevExpress-Examples/how-to-validate-data-rows-e1593)
