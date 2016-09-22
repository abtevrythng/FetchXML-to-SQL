/*
 * Created by SharpDevelop.
 * User: g.nelson
 * Date: 19/09/2016
 * Time: 4:30 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using System.Diagnostics;
using System.Linq;

namespace FetchXML2SQLv2
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public string entityName;
		public List<string> entityAttributes = new List<string>();
		
		public struct linkEntitiesAndAttributes
		{
			public string linkEntityData { get; private set; }
			public string linkEntityAttributeData { get; private set; }
			
			public linkEntitiesAndAttributes(string linkEntityValue, string linkEntityAttributeValue) : this()
			{
				linkEntityData = linkEntityValue;
				linkEntityAttributeData = linkEntityAttributeValue;
			}
		}
		
		public List<linkEntitiesAndAttributes> linkEntitiesAndAttributesList = new List<linkEntitiesAndAttributes>();
		
		public struct linkEntitiesFromTo
		{
			public string linkEntityFromToName { get; private set; }
			public string linkEntityFrom { get; private set; }
			public string linkEntityTo { get; private set; }
			public string linkEntityJoinType { get; private set; }
			
			public linkEntitiesFromTo(string linkEntityValueforFromTo ,string linkEntityFromValue, string linkEntityToValue, string linkEntityJoinTypeValue) : this()
			{
				linkEntityFromToName = linkEntityValueforFromTo;
				linkEntityFrom = linkEntityFromValue;
				linkEntityTo = linkEntityToValue;
				linkEntityJoinType = linkEntityJoinTypeValue;
			}
		}
		
		public List<linkEntitiesFromTo> linkEntitiesFromToList = new List<linkEntitiesFromTo>();
		
		public struct linkEntitiesFilters
		{
			public string linkEntitiesFiltersLinkEntityName { get; private set; }
			public string linkEntitiesFiltersFilterType { get; private set; }
			public string linkEntitiesFiltersLinkEntityAttribute { get; private set; }
			public string linkEntitiesFiltersLinkEntityOperator { get; private set; }
			public string linkEntitiesFiltersLinkEntityValue { get; private set; }
			
			public linkEntitiesFilters(string linkEntitiesFiltersLinkEntityNameValue, string linkEntitiesFiltersFilterTypeValue, string linkEntitiesFiltersLinkEntityAttributeValue, string linkEntitiesFiltersLinkEntityOperatorValue, string linkEntitiesFiltersLinkEntityValueValue) : this()
			{
				linkEntitiesFiltersLinkEntityName = linkEntitiesFiltersLinkEntityNameValue;
				linkEntitiesFiltersFilterType = linkEntitiesFiltersFilterTypeValue;
				linkEntitiesFiltersLinkEntityAttribute = linkEntitiesFiltersLinkEntityAttributeValue;
				linkEntitiesFiltersLinkEntityOperator = linkEntitiesFiltersLinkEntityOperatorValue;
				linkEntitiesFiltersLinkEntityValue = linkEntitiesFiltersLinkEntityValueValue;
			}
			
		}
		
		public List<linkEntitiesFilters> linkEntitiesFiltersList = new List<linkEntitiesFilters>();
		
		public struct mainFilters
		{
			public string mainFiltersEntityName { get; private set; }
			public string mainFiltersFilterType { get; private set; }
			public string mainFiltersEntityAttribute { get; private set; }
			public string mainFiltersEntityOperator { get; private set; }
			public string mainFiltersEntityValue { get; private set; }
			
			public mainFilters(string mainFiltersEntityNameValue, string mainFiltersFilterTypeValue, string mainFiltersEntityAttributeValue, string mainFiltersEntityOperatorValue, string mainFiltersEntityValueValue) : this()
			{
				mainFiltersEntityName = mainFiltersEntityNameValue;
				mainFiltersFilterType = mainFiltersFilterTypeValue;
				mainFiltersEntityAttribute = mainFiltersEntityAttributeValue;
				mainFiltersEntityOperator = mainFiltersEntityOperatorValue;
				mainFiltersEntityValue = mainFiltersEntityValueValue;
			}
			
		}
		
		public List<mainFilters> mainFiltersList = new List<mainFilters>();
		
		public Dictionary<string,string> operatorReplacement = new Dictionary<string, string>();
		public string convertOperator;
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			
			
			operatorReplacement.Add("eq" ,"=");
			operatorReplacement.Add("neq" ,"!=");
			operatorReplacement.Add("ne" ,"!=");
			operatorReplacement.Add("gt" ,">");
			operatorReplacement.Add("ge" ,">=");
			operatorReplacement.Add("le" ,"<=");
			operatorReplacement.Add("lt" ,"<");
			operatorReplacement.Add("like" ,"LIKE");
			operatorReplacement.Add("not-like" ,"NOT LIKE");
			operatorReplacement.Add("in" ,"TBD");
			operatorReplacement.Add("not-in" ,"TBD");
			operatorReplacement.Add("between" ,"TBD");
			operatorReplacement.Add("not-between" ,"TBD");
			operatorReplacement.Add("null" ,"NULL");
			operatorReplacement.Add("not-null" ,"IS NOT NULL");
			operatorReplacement.Add("yesterday" ,"TBD");
			operatorReplacement.Add("today" ,"= CONVERT(DATE, GETDATE())");
			operatorReplacement.Add("tomorrow" ,"= CONVERT(DATE,DATEADD(DAY,1,GETDATE()))");
			operatorReplacement.Add("last-seven-days" ,"TBD");
			operatorReplacement.Add("next-seven-days" ,"TBD");
			operatorReplacement.Add("last-week" ,"TBD");
			operatorReplacement.Add("this-week" ,"TBD");
			operatorReplacement.Add("next-week" ,"TBD");
			operatorReplacement.Add("last-month" ,"TBD");
			operatorReplacement.Add("this-month" ,"TBD");
			operatorReplacement.Add("next-month" ,"TBD");
			operatorReplacement.Add("on" ,"=");
			operatorReplacement.Add("on-or-before" ,"TBD");
			operatorReplacement.Add("on-or-after" ,"TBD");
			operatorReplacement.Add("last-year" ,"TBD");
			operatorReplacement.Add("this-year" ,"TBD");
			operatorReplacement.Add("next-year" ,"TBD");
			operatorReplacement.Add("last-x-hours" ,"TBD");
			operatorReplacement.Add("next-x-hours" ,"TBD");
			operatorReplacement.Add("last-x-days" ,"TBD");
			operatorReplacement.Add("next-x-days" ,"TBD");
			operatorReplacement.Add("last-x-weeks" ,"TBD");
			operatorReplacement.Add("next-x-weeks" ,"TBD");
			operatorReplacement.Add("last-x-months" ,"TBD");
			operatorReplacement.Add("next-x-months" ,"TBD");
			operatorReplacement.Add("olderthan-x-months" ,"TBD");
			operatorReplacement.Add("olderthan-x-years" ,"TBD");
			operatorReplacement.Add("olderthan-x-weeks" ,"TBD");
			operatorReplacement.Add("olderthan-x-days" ,"TBD");
			operatorReplacement.Add("olderthan-x-hours" ,"TBD");
			operatorReplacement.Add("olderthan-x-minutes" ,"TBD");
			operatorReplacement.Add("last-x-years" ,"TBD");
			operatorReplacement.Add("next-x-years" ,"TBD");
			operatorReplacement.Add("eq-userid" ,"=");
			operatorReplacement.Add("ne-userid" ,"!=");
			operatorReplacement.Add("eq-userteams" ,"TBD");
			operatorReplacement.Add("eq-useroruserteams" ,"TBD");
			operatorReplacement.Add("eq-useroruserhierarchy" ,"TBD");
			operatorReplacement.Add("eq-useroruserhierarchyandteams" ,"TBD");
			operatorReplacement.Add("eq-businessid" ,"TBD");
			operatorReplacement.Add("ne-businessid" ,"TBD");
			operatorReplacement.Add("eq-userlanguage" ,"TBD");
			operatorReplacement.Add("this-fiscal-year" ,"TBD");
			operatorReplacement.Add("this-fiscal-period" ,"TBD");
			operatorReplacement.Add("next-fiscal-year" ,"TBD");
			operatorReplacement.Add("next-fiscal-period" ,"TBD");
			operatorReplacement.Add("last-fiscal-year" ,"TBD");
			operatorReplacement.Add("last-fiscal-period" ,"TBD");
			operatorReplacement.Add("last-x-fiscal-years" ,"TBD");
			operatorReplacement.Add("last-x-fiscal-periods" ,"TBD");
			operatorReplacement.Add("next-x-fiscal-years" ,"TBD");
			operatorReplacement.Add("next-x-fiscal-periods" ,"TBD");
			operatorReplacement.Add("in-fiscal-year" ,"TBD");
			operatorReplacement.Add("in-fiscal-period" ,"TBD");
			operatorReplacement.Add("in-fiscal-period-and-year" ,"TBD");
			operatorReplacement.Add("in-or-before-fiscal-period-and-year" ,"TBD");
			operatorReplacement.Add("in-or-after-fiscal-period-and-year" ,"TBD");
			operatorReplacement.Add("begins-with" ,"= %");
			operatorReplacement.Add("not-begin-with" ,"!= %");
			operatorReplacement.Add("ends-with" ,"=");
			operatorReplacement.Add("not-end-with" ,"!=");
			operatorReplacement.Add("under","TBD");
			operatorReplacement.Add("eq-or-under" ,"TBD");
			operatorReplacement.Add("not-under","TBD");
			operatorReplacement.Add("above" ,"TBD");
			operatorReplacement.Add("eq-or-above" ,"TBD");
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			
		}
		void Button1Click(object sender, EventArgs e)
		{
			//Load the fetchXML
			if (fetchXMLBox.Text == "")
				{
					MessageBox.Show("Please enter some fetchXML!", "Really?", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							return;
				}
			
			if (fetchXMLBox.Text.TrimStart().StartsWith("<") == false)
				{
				MessageBox.Show("Please enter some fetchXML!", "Really?", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							return;
				}
			
			XmlDocument xmldoc = new XmlDocument();
			
			try 
			{				
				xmldoc.LoadXml(fetchXMLBox.Text);
			}
			
			catch (Exception)
			{
				MessageBox.Show("Looks like this is not a valid fetchXML!", "Please Check", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
						
			
			
			//Clear all contents from output and lists
			sqlBox.Text = "";
			entityName = "";
			entityAttributes.Clear();
			linkEntitiesAndAttributesList.Clear();
			linkEntitiesFromToList.Clear();
			linkEntitiesFiltersList.Clear();
			mainFiltersList.Clear();
			
			
			//Get the main entity from fetchXML
			foreach (XmlNode entityNode in xmldoc.GetElementsByTagName("entity"))
			{
				entityName = entityNode.Attributes["name"].InnerText;
				//Debug.WriteLine(entityName);
			}
			
			//get all the attributes for the main entity and put them in a list.
			foreach (XmlNode entityAttributeNode in xmldoc.DocumentElement.SelectNodes("/fetch/entity/attribute"))
			{
				entityAttributes.Add(entityAttributeNode.Attributes["name"].InnerText);
			}
			
			//Get all link entities and their attributes
			foreach (XmlNode linkEntity in xmldoc.DocumentElement.SelectNodes("/fetch/entity/link-entity"))
			{
				//check if there are any attributes for the link entity
				if (linkEntity.HasChildNodes)
				{
					for (int i=0; i < linkEntity.ChildNodes.Count; i++)
					{
						if (linkEntity.ChildNodes[i].Attributes["name"] != null)
						{
							//linkEntitiesAndAttributes.Add(linkEntity.Attributes["name"].InnerText, linkEntity.ChildNodes[i].Attributes["name"].InnerText);
							linkEntitiesAndAttributesList.Add(new linkEntitiesAndAttributes(linkEntity.Attributes["name"].InnerText, linkEntity.ChildNodes[i].Attributes["name"].InnerText));
						}
					}
				}
				
				//get from and to fields for the joins
				if (linkEntity.Attributes["from"] != null && linkEntity.Attributes["to"] != null)
					{
						string getLinkType;
						if (linkEntity.Attributes["link-type"] != null)
							{
								getLinkType = linkEntity.Attributes["link-type"].InnerText;
								getLinkType = "LEFT " + getLinkType.ToUpper();
							}
						else 
								getLinkType = "INNER";
								//getLinkType = "";
						
						linkEntitiesFromToList.Add(new linkEntitiesFromTo(linkEntity.Attributes["name"].InnerText, linkEntity.Attributes["from"].InnerText, linkEntity.Attributes["to"].InnerText, getLinkType));
					}
			}
			
			//get all link entities and their filters
			foreach (XmlNode linkEntityFilter in xmldoc.DocumentElement.SelectNodes("/fetch/entity/link-entity/filter"))
			{
				if (linkEntityFilter.HasChildNodes)
				{
					for (int i=0; i < linkEntityFilter.ChildNodes.Count; i++)
					{
						//check if there are multiple filters
						if (linkEntityFilter.ChildNodes[i].Name == "filter")
						{
							MessageBox.Show("Filters within filters are currently not supported!", "Please Note", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							return;
						}
						
						if (linkEntityFilter.ChildNodes[i].Attributes["operator"] != null)
							{
								operatorReplacement.TryGetValue(linkEntityFilter.ChildNodes[i].Attributes["operator"].InnerText, out convertOperator);
								//Debug.WriteLine(convertOperator);
							}
						
						if (linkEntityFilter.ChildNodes[i].Attributes["value"] != null)
						{
							linkEntitiesFiltersList.Add(new linkEntitiesFilters(linkEntityFilter.ParentNode.Attributes["name"].InnerText, linkEntityFilter.Attributes["type"].InnerText.ToUpper(), linkEntityFilter.ChildNodes[i].Attributes["attribute"].InnerText, convertOperator, linkEntityFilter.ChildNodes[i].Attributes["value"].InnerText));
						}
						else
							linkEntitiesFiltersList.Add(new linkEntitiesFilters(linkEntityFilter.ParentNode.Attributes["name"].InnerText, linkEntityFilter.Attributes["type"].InnerText.ToUpper(), linkEntityFilter.ChildNodes[i].Attributes["attribute"].InnerText, convertOperator, ""));
					}
				}
			}
			
			//get all filters for main entity
			foreach (XmlNode mainFilter in xmldoc.DocumentElement.SelectNodes("/fetch/entity/filter"))
			{
				if (mainFilter.HasChildNodes)
				{
					for (int i=0; i < mainFilter.ChildNodes.Count; i++)
					{
						if (mainFilter.ChildNodes[i].Attributes["operator"] != null)
							{
								operatorReplacement.TryGetValue(mainFilter.ChildNodes[i].Attributes["operator"].InnerText, out convertOperator);
								//Debug.WriteLine(convertOperator);
							}
						
						if (mainFilter.ChildNodes[i].Attributes["value"] != null)
						{
							mainFiltersList.Add(new mainFilters(mainFilter.ParentNode.Attributes["name"].InnerText, mainFilter.Attributes["type"].InnerText.ToUpper(), mainFilter.ChildNodes[i].Attributes["attribute"].InnerText, convertOperator, mainFilter.ChildNodes[i].Attributes["value"].InnerText));
						}
						else
							mainFiltersList.Add(new mainFilters(mainFilter.ParentNode.Attributes["name"].InnerText, mainFilter.Attributes["type"].InnerText.ToUpper(), mainFilter.ChildNodes[i].Attributes["attribute"].InnerText, convertOperator, ""));
					}
				}
			}
			
			sqlBox.AppendText("SELECT ",Color.Green, FontStyle.Bold);
			
			foreach (string attributes in entityAttributes)
			{
				//sb.Append(entityName + "." + attributes + ", ");
				string tempString = entityName + "." + attributes + ", ";
				
				var lastItem = entityAttributes.Last();
				
				if (attributes == lastItem)
				{
					tempString = entityName + "." + attributes;
					//Debug.WriteLine("I Ran");
				}
				
				sqlBox.AppendText(tempString, Color.Black, FontStyle.Regular);
				
			}
			
			//sqlBox.AppendText("SELECT ",Color.Green);
			
			foreach (linkEntitiesAndAttributes myStruct in linkEntitiesAndAttributesList)
			{
				string tempString = ", " + myStruct.linkEntityData + "." + myStruct.linkEntityAttributeData;
				
				/*var lastItem = linkEntitiesAndAttributesList.Last();
				
				if (myStruct.linkEntityData  == lastItem.linkEntityData && myStruct.linkEntityAttributeData == lastItem.linkEntityAttributeData)
				{
					tempString = tempString.Substring(0, tempString.Length - 2);
					//Debug.WriteLine("I Ran");
				}*/
								
				sqlBox.AppendText(tempString, Color.Black, FontStyle.Regular);
			}
			
			sqlBox.AppendText(System.Environment.NewLine);
			sqlBox.AppendText("FROM ",Color.Green, FontStyle.Bold);
			sqlBox.AppendText(entityName,Color.Black, FontStyle.Regular);
			
			foreach (linkEntitiesFromTo myStruct in linkEntitiesFromToList)
			{
				sqlBox.AppendText(System.Environment.NewLine);
				sqlBox.AppendText(myStruct.linkEntityJoinType + " JOIN ", Color.Green, FontStyle.Bold);
				
				sqlBox.AppendText(myStruct.linkEntityFromToName, Color.Black, FontStyle.Regular);
				
				sqlBox.AppendText(" ON ", Color.Green, FontStyle.Bold);
				
				string tempString = entityName + "." + myStruct.linkEntityFrom + " = " + myStruct.linkEntityFromToName + "." + myStruct.linkEntityTo;
				
				sqlBox.AppendText(tempString, Color.Black, FontStyle.Regular);
				
				bool writtenANDOnce;

				writtenANDOnce = false;

				
				foreach (linkEntitiesFilters myFilterstruct in linkEntitiesFiltersList)
				{
					
					if (myStruct.linkEntityFromToName == myFilterstruct.linkEntitiesFiltersLinkEntityName)
					{
						
						
						if (writtenANDOnce == false)
						{
							sqlBox.AppendText(" AND ", Color.Green, FontStyle.Bold);
							writtenANDOnce = true;
						}
						
						sqlBox.AppendText(myFilterstruct.linkEntitiesFiltersLinkEntityName + "." + myFilterstruct.linkEntitiesFiltersLinkEntityAttribute + " " + myFilterstruct.linkEntitiesFiltersLinkEntityOperator + " '" + myFilterstruct.linkEntitiesFiltersLinkEntityValue + "' ", Color.Black, FontStyle.Regular);
						
						var lastItem = linkEntitiesFiltersList.Last();
						
						if (writtenANDOnce == true && (myFilterstruct.linkEntitiesFiltersLinkEntityValue != lastItem.linkEntitiesFiltersLinkEntityValue || myFilterstruct.linkEntitiesFiltersLinkEntityAttribute != lastItem.linkEntitiesFiltersLinkEntityAttribute || myFilterstruct.linkEntitiesFiltersLinkEntityName != lastItem.linkEntitiesFiltersLinkEntityName) )
						{
							sqlBox.AppendText(" " + myFilterstruct.linkEntitiesFiltersFilterType + " ", Color.Green, FontStyle.Bold);
						}
					}
				}
				
				
				
			}
			
			if (mainFiltersList.Count != 0)
			{
				sqlBox.AppendText(System.Environment.NewLine);
				sqlBox.AppendText("WHERE ",Color.Green, FontStyle.Bold);
			}
			
			
			foreach (mainFilters myMainFilter in mainFiltersList)
			{
				var lastItem = mainFiltersList.Last();
				
				if (myMainFilter.mainFiltersEntityValue == "")
				{
					sqlBox.AppendText(myMainFilter.mainFiltersEntityName + "." + myMainFilter.mainFiltersEntityAttribute + " " + myMainFilter.mainFiltersEntityOperator, Color.Black, FontStyle.Regular);
				}
				else
					sqlBox.AppendText(myMainFilter.mainFiltersEntityName + "." + myMainFilter.mainFiltersEntityAttribute + " " + myMainFilter.mainFiltersEntityOperator + " '" + myMainFilter.mainFiltersEntityValue + "' ", Color.Black, FontStyle.Regular);
				
				if (myMainFilter.mainFiltersEntityAttribute != lastItem.mainFiltersEntityAttribute || myMainFilter.mainFiltersEntityOperator != lastItem.mainFiltersEntityOperator || myMainFilter.mainFiltersEntityValue != lastItem.mainFiltersEntityValue)
				{
					sqlBox.AppendText(" " + myMainFilter.mainFiltersFilterType + " ", Color.Green, FontStyle.Bold);
				}
			}
			
			
			
		}

	}
	
	public static class RichTextBoxExtensions
	{
		public static void AppendText(this RichTextBox box, string text, Color color, FontStyle fontstyle)
    	{
			box.SelectionStart = box.TextLength;
			box.SelectionLength = 0;

			box.SelectionColor = color;
			box.SelectionFont = new Font(box.Font, fontstyle);
			box.AppendText(text);
			box.SelectionColor = box.ForeColor;
    	}
	}
	
}
