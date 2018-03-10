#pragma once
#include<Windows.h>
#include<atlstr.h>
#include<msclr\marshal_cppstd.h>
#include<msclr\marshal.h>
#include<msclr\marshal_windows.h>

static HKEY OHKEY, CHKEY;
static HKEY CURRENT_HKEY;
namespace Lab2 {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;
	using namespace std;
	/// <summary>
	/// Сводка для form
	/// </summary>




	public ref class form : public System::Windows::Forms::Form
	{
	public:
		form(void)
		{
			InitializeComponent();
			//
			//TODO: добавьте код конструктора
			//
		}

	protected:
		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		~form()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::TextBox^  textBox1;
	private: System::Windows::Forms::TextBox^  textBox2;

	private: System::Windows::Forms::Button^  button2;
	private: System::Windows::Forms::TextBox^  textBox3;
	private: System::Windows::Forms::Button^  button3;
	private: System::Windows::Forms::TextBox^  textBox4;
	private: System::Windows::Forms::Button^  button4;
	private: System::Windows::Forms::TextBox^  textBox5;
	private: System::Windows::Forms::TextBox^  textBox6;
	private: System::Windows::Forms::TextBox^  textBox7;
	private: System::Windows::Forms::Button^  button5;
	private: System::Windows::Forms::TextBox^  textBox8;
	private: System::Windows::Forms::TextBox^  textBox9;
	private: System::Windows::Forms::ListBox^  listBox1;
	private: System::Windows::Forms::TextBox^  textBox10;
	private: System::Windows::Forms::ComboBox^  comboBox1;
	protected:
	private:
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		void InitializeComponent(void)
		{
			this->textBox1 = (gcnew System::Windows::Forms::TextBox());
			this->textBox2 = (gcnew System::Windows::Forms::TextBox());
			this->button2 = (gcnew System::Windows::Forms::Button());
			this->textBox3 = (gcnew System::Windows::Forms::TextBox());
			this->button3 = (gcnew System::Windows::Forms::Button());
			this->textBox4 = (gcnew System::Windows::Forms::TextBox());
			this->button4 = (gcnew System::Windows::Forms::Button());
			this->textBox5 = (gcnew System::Windows::Forms::TextBox());
			this->textBox6 = (gcnew System::Windows::Forms::TextBox());
			this->textBox7 = (gcnew System::Windows::Forms::TextBox());
			this->button5 = (gcnew System::Windows::Forms::Button());
			this->textBox8 = (gcnew System::Windows::Forms::TextBox());
			this->textBox9 = (gcnew System::Windows::Forms::TextBox());
			this->listBox1 = (gcnew System::Windows::Forms::ListBox());
			this->textBox10 = (gcnew System::Windows::Forms::TextBox());
			this->comboBox1 = (gcnew System::Windows::Forms::ComboBox());
			this->SuspendLayout();
			// 
			// textBox1
			// 
			this->textBox1->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->textBox1->Location = System::Drawing::Point(370, 38);
			this->textBox1->Name = L"textBox1";
			this->textBox1->ReadOnly = true;
			this->textBox1->Size = System::Drawing::Size(199, 20);
			this->textBox1->TabIndex = 0;
			// 
			// textBox2
			// 
			this->textBox2->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->textBox2->Location = System::Drawing::Point(370, 64);
			this->textBox2->Name = L"textBox2";
			this->textBox2->ReadOnly = true;
			this->textBox2->Size = System::Drawing::Size(199, 20);
			this->textBox2->TabIndex = 1;
			this->textBox2->TextChanged += gcnew System::EventHandler(this, &form::textBox2_TextChanged);
			// 
			// button2
			// 
			this->button2->Location = System::Drawing::Point(196, 36);
			this->button2->Name = L"button2";
			this->button2->Size = System::Drawing::Size(168, 23);
			this->button2->TabIndex = 3;
			this->button2->Text = L"Open Directory (HKCU)";
			this->button2->UseVisualStyleBackColor = true;
			this->button2->Click += gcnew System::EventHandler(this, &form::button2_Click);
			// 
			// textBox3
			// 
			this->textBox3->Location = System::Drawing::Point(12, 38);
			this->textBox3->Name = L"textBox3";
			this->textBox3->Size = System::Drawing::Size(178, 20);
			this->textBox3->TabIndex = 4;
			// 
			// button3
			// 
			this->button3->Location = System::Drawing::Point(196, 62);
			this->button3->Name = L"button3";
			this->button3->Size = System::Drawing::Size(168, 23);
			this->button3->TabIndex = 5;
			this->button3->Text = L"Create/Open Directory (HKCU)";
			this->button3->UseVisualStyleBackColor = true;
			this->button3->Click += gcnew System::EventHandler(this, &form::button3_Click);
			// 
			// textBox4
			// 
			this->textBox4->Location = System::Drawing::Point(12, 64);
			this->textBox4->Name = L"textBox4";
			this->textBox4->Size = System::Drawing::Size(178, 20);
			this->textBox4->TabIndex = 6;
			this->textBox4->Text = L"Software\\Sysprog";
			// 
			// button4
			// 
			this->button4->Location = System::Drawing::Point(299, 91);
			this->button4->Name = L"button4";
			this->button4->Size = System::Drawing::Size(156, 23);
			this->button4->TabIndex = 7;
			this->button4->Text = L"Add Pair Param/Value";
			this->button4->UseVisualStyleBackColor = true;
			this->button4->Click += gcnew System::EventHandler(this, &form::button4_Click);
			// 
			// textBox5
			// 
			this->textBox5->Location = System::Drawing::Point(12, 93);
			this->textBox5->Name = L"textBox5";
			this->textBox5->Size = System::Drawing::Size(149, 20);
			this->textBox5->TabIndex = 8;
			this->textBox5->Text = L"Param";
			// 
			// textBox6
			// 
			this->textBox6->Location = System::Drawing::Point(167, 93);
			this->textBox6->Name = L"textBox6";
			this->textBox6->Size = System::Drawing::Size(126, 20);
			this->textBox6->TabIndex = 9;
			this->textBox6->Text = L"Value";
			// 
			// textBox7
			// 
			this->textBox7->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->textBox7->Location = System::Drawing::Point(461, 93);
			this->textBox7->Name = L"textBox7";
			this->textBox7->ReadOnly = true;
			this->textBox7->Size = System::Drawing::Size(108, 20);
			this->textBox7->TabIndex = 10;
			// 
			// button5
			// 
			this->button5->Location = System::Drawing::Point(196, 120);
			this->button5->Name = L"button5";
			this->button5->Size = System::Drawing::Size(168, 23);
			this->button5->TabIndex = 11;
			this->button5->Text = L"Find by Param Name";
			this->button5->UseVisualStyleBackColor = true;
			this->button5->Click += gcnew System::EventHandler(this, &form::button5_Click);
			// 
			// textBox8
			// 
			this->textBox8->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->textBox8->Location = System::Drawing::Point(370, 122);
			this->textBox8->Name = L"textBox8";
			this->textBox8->ReadOnly = true;
			this->textBox8->Size = System::Drawing::Size(199, 20);
			this->textBox8->TabIndex = 12;
			// 
			// textBox9
			// 
			this->textBox9->Location = System::Drawing::Point(12, 122);
			this->textBox9->Name = L"textBox9";
			this->textBox9->Size = System::Drawing::Size(178, 20);
			this->textBox9->TabIndex = 13;
			// 
			// listBox1
			// 
			this->listBox1->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom)
				| System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->listBox1->FormattingEnabled = true;
			this->listBox1->Location = System::Drawing::Point(12, 148);
			this->listBox1->Name = L"listBox1";
			this->listBox1->Size = System::Drawing::Size(557, 121);
			this->listBox1->TabIndex = 14;
			// 
			// textBox10
			// 
			this->textBox10->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->textBox10->Location = System::Drawing::Point(12, 275);
			this->textBox10->Name = L"textBox10";
			this->textBox10->Size = System::Drawing::Size(557, 20);
			this->textBox10->TabIndex = 15;
			// 
			// comboBox1
			// 
			this->comboBox1->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->comboBox1->DropDownStyle = System::Windows::Forms::ComboBoxStyle::DropDownList;
			this->comboBox1->FormattingEnabled = true;
			this->comboBox1->Items->AddRange(gcnew cli::array< System::Object^  >(5) {
				L"HKEY_CURRENT_USER", L"HKEY_LOCAL_MACHINE", L"HKEY_CLASSES_ROOT",
					L"HKEY_CURRENT_CONFIG", L"HKEY_USERS"
			});
			this->comboBox1->Location = System::Drawing::Point(12, 12);
			this->comboBox1->Name = L"comboBox1";
			this->comboBox1->Size = System::Drawing::Size(557, 21);
			this->comboBox1->TabIndex = 16;
			this->comboBox1->SelectedIndexChanged += gcnew System::EventHandler(this, &form::comboBox1_SelectedIndexChanged);
			// 
			// form
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(576, 306);
			this->Controls->Add(this->comboBox1);
			this->Controls->Add(this->textBox10);
			this->Controls->Add(this->listBox1);
			this->Controls->Add(this->textBox9);
			this->Controls->Add(this->textBox8);
			this->Controls->Add(this->button5);
			this->Controls->Add(this->textBox7);
			this->Controls->Add(this->textBox6);
			this->Controls->Add(this->textBox5);
			this->Controls->Add(this->button4);
			this->Controls->Add(this->textBox4);
			this->Controls->Add(this->button3);
			this->Controls->Add(this->textBox3);
			this->Controls->Add(this->button2);
			this->Controls->Add(this->textBox2);
			this->Controls->Add(this->textBox1);
			this->Name = L"form";
			this->Text = L"System programming. Lab 2";
			this->FormClosed += gcnew System::Windows::Forms::FormClosedEventHandler(this, &form::form_FormClosed);
			this->Load += gcnew System::EventHandler(this, &form::form_Load);
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion

	private: System::Void form_Load(System::Object^  sender, System::EventArgs^  e) {
		HKEY tKey; DWORD type = REG_SZ;
		button4->Enabled = false;
		button5->Enabled = false;
		comboBox1->SelectedIndex = 0;
		CURRENT_HKEY = HKEY_CURRENT_USER;
		int d = -1;
		if (RegCreateKeyExW(HKEY_CURRENT_USER, TEXT("Software\\workingpartlab2"), NULL, TEXT(""), REG_OPTION_NON_VOLATILE, KEY_ALL_ACCESS, NULL, &tKey, NULL) == ERROR_SUCCESS)
		{
			DWORD size = 256;
			wchar_t *data = (wchar_t*)malloc(size * sizeof(wchar_t));
			d = RegGetValueW(HKEY_CURRENT_USER, TEXT("Software\\workingpartlab2"), TEXT("textinbox"), RRF_RT_REG_SZ, &type, data, &size);
			textBox10->Text = msclr::interop::marshal_as<String^>(wstring(data));
			RegCloseKey(tKey);
			free(data);
		}
		else
			textBox10->Text = "ERROR";
	}

private: System::Void button2_Click(System::Object^  sender, System::EventArgs^  e) {

	msclr::interop::marshal_context mc;
	LPWSTR subString = mc.marshal_as<LPWSTR>(textBox3->Text);

	long openkeyres = RegOpenKeyExW(CURRENT_HKEY, subString, 0, KEY_ALL_ACCESS, &OHKEY);
	if (openkeyres != ERROR_SUCCESS)
	{
		textBox1->Text = "Wrong directory!";
		return;
	}
	textBox1->Text = "Succeeded!";
	}

private: System::Void form_FormClosed(System::Object^  sender, System::Windows::Forms::FormClosedEventArgs^  e) {
	RegCloseKey(CHKEY);
	RegCloseKey(OHKEY);
	HKEY tKey;
	RegOpenKeyExW(HKEY_CURRENT_USER, TEXT("Software\\workingpartlab2"), 0, KEY_ALL_ACCESS, &tKey);
	wstring message = msclr::interop::marshal_as<wstring>(textBox10->Text);
	RegSetValueExW(tKey, TEXT("textinbox"), 0, REG_SZ, (LPBYTE)message.c_str(), sizeof(wchar_t)*(message.size() + 1));
	RegCloseKey(tKey);
	}

private: System::Void textBox2_TextChanged(System::Object^  sender, System::EventArgs^  e) {
	}

private: System::Void button3_Click(System::Object^  sender, System::EventArgs^  e) {
	msclr::interop::marshal_context mc;
	SubPath = textBox4->Text;
	LPWSTR subString = mc.marshal_as<LPWSTR>(textBox4->Text);
	
	DWORD disp;//LPDWORD disp err?
	long ckeyres = RegCreateKeyExW(CURRENT_HKEY, subString, NULL, TEXT(""), REG_OPTION_NON_VOLATILE, KEY_ALL_ACCESS, NULL, &CHKEY, &disp);
	
	wchar_t buf[256];
	FormatMessageW(FORMAT_MESSAGE_FROM_SYSTEM | FORMAT_MESSAGE_IGNORE_INSERTS,
		NULL, ckeyres, MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT),
		buf, sizeof(buf), NULL);
	wstring ws(buf);
	String^ str = msclr::interop::marshal_as<String^>(ws);
	textBox2->Text = str;

	if (ckeyres != ERROR_SUCCESS)
		return;

	button4->Enabled = true;
	button5->Enabled = true;
	if (disp == REG_CREATED_NEW_KEY)
		textBox2->Text += " Создан новый ключ.";
	else
		if (disp == REG_OPENED_EXISTING_KEY)
			textBox2->Text += " Открыт существующий ключ.";
		else
			textBox2->Text += " Неизвестное состояние.";
	}
private: System::Void button4_Click(System::Object^  sender, System::EventArgs^  e) {
	msclr::interop::marshal_context mc;
	LPWSTR valuename = mc.marshal_as<LPWSTR>(textBox5->Text);
	wstring message = msclr::interop::marshal_as<wstring>(textBox6->Text);
	long svres = RegSetValueEx(CHKEY, valuename, 0, REG_SZ, (LPBYTE)message.c_str(), sizeof(wchar_t)*(message.size() + 1));

	wchar_t buf[256];
	FormatMessageW(FORMAT_MESSAGE_FROM_SYSTEM | FORMAT_MESSAGE_IGNORE_INSERTS,
		NULL, svres, MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT),
		buf, sizeof(buf), NULL);
	wstring ws(buf);
	String^ str = msclr::interop::marshal_as<String^>(ws);
	textBox7->Text = str;

}
public: String ^ SubPath;

private: void FindEntries(HKEY &key,String^ entry,String^ currLoc)
{
	DWORD lpcSubKeys, lpcbMaxSubKeyLen, lpcbMaxClassLen, lpcValues, lpcbMaxValueNameLen, lpcbMaxValueLen;
	long r = RegQueryInfoKeyW(key, NULL, NULL, NULL, &lpcSubKeys, &lpcbMaxSubKeyLen, &lpcbMaxClassLen, &lpcValues, &lpcbMaxValueNameLen, &lpcbMaxValueLen, NULL, NULL);

	if (lpcSubKeys != 0)
	{
		DWORD index = 0;
		wchar_t *lpName = (wchar_t*)malloc((lpcbMaxSubKeyLen + 1) * sizeof(wchar_t)); DWORD lpcchName = lpcbMaxSubKeyLen+1;
		int result;
		while ((result = RegEnumKeyExW(key, index, lpName, &lpcchName, 0, NULL, NULL, NULL)) != ERROR_NO_MORE_ITEMS)
		{
			if (result != ERROR_SUCCESS) break;
			wstring ws(lpName);
			wstring loc = msclr::interop::marshal_as<wstring>(currLoc);
			loc.push_back('\\');
			loc.append(ws);
			String^ location = msclr::interop::marshal_as<String^>(loc);
			HKEY tempKey;
			OutputDebugStringW(loc.c_str());
			OutputDebugStringW(TEXT("\n"));
			if(RegOpenKeyExW(CURRENT_HKEY, loc.c_str(), 0, KEY_ALL_ACCESS, &tempKey) == ERROR_SUCCESS)
				FindEntries(tempKey, entry, location);
			RegCloseKey(tempKey);
			lpcchName = lpcbMaxSubKeyLen + 1; 
			index++;
		}
		free(lpName);
	}
	if (lpcValues != 0)
		FindValues(key, entry, lpcbMaxValueNameLen, lpcbMaxValueLen, currLoc);
}

private: void FindValues(HKEY key, String^ entry,DWORD lpcbMaxValueNameLen,DWORD lpcbMaxValueLen,String^ loc)
{
	DWORD iterator = 0;
	wchar_t *lpValueName = (wchar_t*)malloc((lpcbMaxValueNameLen + 1) * sizeof(wchar_t)); DWORD lpcchValueName = lpcbMaxValueNameLen, lpType = REG_NONE, lpcbData = lpcbMaxValueLen;
	long enumres;

	while ((enumres = RegEnumValueW(key, iterator, lpValueName, &lpcchValueName, 0, &lpType, NULL, &lpcbData)) != ERROR_NO_MORE_ITEMS)
	{
		if (lpType == REG_SZ)
		{
			lpcchValueName = lpcbMaxValueNameLen + 1;
			wchar_t *buffer = new wchar_t[(lpcbData + 1) * sizeof(wchar_t)];
			enumres = RegEnumValueW(key, iterator, lpValueName, &lpcchValueName, 0, &lpType, (LPBYTE)buffer, &lpcbData);

			if (buffer[0] != 0 && lpValueName[0] != 0 && lpcbData != 0) {
				wstring name(lpValueName);
				OutputDebugStringW(name.c_str());
				String^ mname = msclr::interop::marshal_as<String^>(name);
				if (mname->Equals(entry) || entry->Equals(String::Empty))
				{
					wstring val(buffer);
					String^ mval = msclr::interop::marshal_as<String^>(val);
					
					listBox1->Items->Add(comboBox1->Items[comboBox1->SelectedIndex] +"\\" + loc + " ||| " + mname + " : " + mval);
				}
			}
			;
			free(buffer);
		}
		lpcchValueName = lpcbMaxValueNameLen + 1; lpcbData = 0;
		iterator++;
	}
	free(lpValueName);
}
private: System::Void button5_Click(System::Object^  sender, System::EventArgs^  e) {
	listBox1->Items->Clear();
	FindEntries(CHKEY, textBox9->Text, SubPath);

}
private: System::Void comboBox1_SelectedIndexChanged(System::Object^  sender, System::EventArgs^  e) {
	switch (comboBox1->SelectedIndex)
	{
	case 0: CURRENT_HKEY = HKEY_CURRENT_USER; break;
	case 1: CURRENT_HKEY = HKEY_LOCAL_MACHINE; break;
	case 2: CURRENT_HKEY = HKEY_CLASSES_ROOT; break;
	case 3: CURRENT_HKEY = HKEY_CURRENT_CONFIG; break;
	case 4: CURRENT_HKEY = HKEY_USERS;  break;
	}
	button4->Enabled = false;
	button5->Enabled = false;
}
};
}