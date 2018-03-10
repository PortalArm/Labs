#pragma once
#include<Windows.h>
#include<string>
#include<atlstr.h>
#include<msclr\marshal_cppstd.h>
#include<msclr\marshal.h>
#include<msclr\marshal_windows.h>
#include<iostream>
#include<Strsafe.h>

namespace Sysprog {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;
	using namespace std;
	std::wstring s2ws(const std::string& s)
	{
		int len;
		int slength = (int)s.length() + 1;
		len = MultiByteToWideChar(CP_ACP, 0, s.c_str(), slength, 0, 0);
		wchar_t* buf = new wchar_t[len];
		MultiByteToWideChar(CP_ACP, 0, s.c_str(), slength, buf, len);
		std::wstring r(buf);
		delete[] buf;
		return r;
	}

	bool Block = false,breakafter5 = false;
	CRITICAL_SECTION LPS;
	int ZZ = 100, slptime = 1000;

	DWORD WINAPI Func1(LPVOID lpParam)
	{
		for (int i = 0; i < 12; ++i)
		{
			if(Block) EnterCriticalSection(&LPS);
			ZZ = ZZ + 1;
			cout << ZZ << "|"<< *(int*)lpParam << "|" << endl;
			Sleep(slptime);
			if(Block)LeaveCriticalSection(&LPS);
			if (breakafter5 && i==5) break;
		}
		return ZZ;
	}
	DWORD WINAPI Func2(LPVOID lpParam)
	{
		for (int i = 0; i < 12; ++i)
		{
			if (Block) EnterCriticalSection(&LPS);
			ZZ = ZZ + 1;
			cout << ZZ << "|" << *(int*)lpParam << "|" << endl;
			Sleep(slptime);
			if (Block)LeaveCriticalSection(&LPS);
		}
		return ZZ;
	}

	public ref class MyForm : public System::Windows::Forms::Form
	{
	public:
		MyForm(void)
		{
			InitializeComponent();
		}

	protected:
		~MyForm()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::OpenFileDialog^  openFileDialog1;
	protected:
	private: System::Windows::Forms::TextBox^  FileBox;
	private: System::Windows::Forms::Button^  ChooseFileButton;
	private: System::Windows::Forms::Button^  ExecuteButton;
	private: System::Windows::Forms::Button^  button1;
	private: System::Windows::Forms::Button^  Thread1Button;
	private: System::Windows::Forms::TextBox^  OutputBox;
	private: System::Windows::Forms::CheckBox^  checkBox1;
	private: System::Windows::Forms::Label^  label1;
	private: System::Windows::Forms::TextBox^  textBox1;
	private: System::Windows::Forms::Label^  label2;
	private: System::Windows::Forms::CheckBox^  checkBox2;


	private:
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		void InitializeComponent(void)
		{
			this->openFileDialog1 = (gcnew System::Windows::Forms::OpenFileDialog());
			this->FileBox = (gcnew System::Windows::Forms::TextBox());
			this->ChooseFileButton = (gcnew System::Windows::Forms::Button());
			this->ExecuteButton = (gcnew System::Windows::Forms::Button());
			this->button1 = (gcnew System::Windows::Forms::Button());
			this->Thread1Button = (gcnew System::Windows::Forms::Button());
			this->OutputBox = (gcnew System::Windows::Forms::TextBox());
			this->checkBox1 = (gcnew System::Windows::Forms::CheckBox());
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->textBox1 = (gcnew System::Windows::Forms::TextBox());
			this->label2 = (gcnew System::Windows::Forms::Label());
			this->checkBox2 = (gcnew System::Windows::Forms::CheckBox());
			this->SuspendLayout();
			// 
			// openFileDialog1
			// 
			this->openFileDialog1->FileName = L"openFileDialog1";
			this->openFileDialog1->FileOk += gcnew System::ComponentModel::CancelEventHandler(this, &MyForm::openFileDialog1_FileOk);
			// 
			// FileBox
			// 
			this->FileBox->Location = System::Drawing::Point(12, 12);
			this->FileBox->Name = L"FileBox";
			this->FileBox->Size = System::Drawing::Size(354, 20);
			this->FileBox->TabIndex = 0;
			// 
			// ChooseFileButton
			// 
			this->ChooseFileButton->Location = System::Drawing::Point(372, 10);
			this->ChooseFileButton->Name = L"ChooseFileButton";
			this->ChooseFileButton->Size = System::Drawing::Size(102, 23);
			this->ChooseFileButton->TabIndex = 1;
			this->ChooseFileButton->Text = L"Выбрать файл";
			this->ChooseFileButton->UseVisualStyleBackColor = true;
			this->ChooseFileButton->Click += gcnew System::EventHandler(this, &MyForm::ChooseFileButton_Click);
			// 
			// ExecuteButton
			// 
			this->ExecuteButton->Location = System::Drawing::Point(12, 38);
			this->ExecuteButton->Name = L"ExecuteButton";
			this->ExecuteButton->Size = System::Drawing::Size(151, 23);
			this->ExecuteButton->TabIndex = 2;
			this->ExecuteButton->Text = L"Запустить (WinExec)";
			this->ExecuteButton->UseVisualStyleBackColor = true;
			this->ExecuteButton->Click += gcnew System::EventHandler(this, &MyForm::ExecuteButton_Click);
			// 
			// button1
			// 
			this->button1->Location = System::Drawing::Point(12, 67);
			this->button1->Name = L"button1";
			this->button1->Size = System::Drawing::Size(151, 23);
			this->button1->TabIndex = 3;
			this->button1->Text = L"Запустить (CreateProcess)";
			this->button1->UseVisualStyleBackColor = true;
			this->button1->Click += gcnew System::EventHandler(this, &MyForm::button1_Click);
			// 
			// Thread1Button
			// 
			this->Thread1Button->Location = System::Drawing::Point(12, 96);
			this->Thread1Button->Name = L"Thread1Button";
			this->Thread1Button->Size = System::Drawing::Size(151, 23);
			this->Thread1Button->TabIndex = 4;
			this->Thread1Button->Text = L"Создать потоки";
			this->Thread1Button->UseVisualStyleBackColor = true;
			this->Thread1Button->Click += gcnew System::EventHandler(this, &MyForm::Thread1Button_Click);
			// 
			// OutputBox
			// 
			this->OutputBox->Location = System::Drawing::Point(77, 151);
			this->OutputBox->Name = L"OutputBox";
			this->OutputBox->ReadOnly = true;
			this->OutputBox->Size = System::Drawing::Size(100, 20);
			this->OutputBox->TabIndex = 5;
			// 
			// checkBox1
			// 
			this->checkBox1->AutoSize = true;
			this->checkBox1->Location = System::Drawing::Point(169, 100);
			this->checkBox1->Name = L"checkBox1";
			this->checkBox1->Size = System::Drawing::Size(92, 17);
			this->checkBox1->TabIndex = 6;
			this->checkBox1->Text = L"Крит. секция";
			this->checkBox1->UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Location = System::Drawing::Point(12, 154);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(59, 13);
			this->label1->TabIndex = 7;
			this->label1->Text = L"Результат";
			// 
			// textBox1
			// 
			this->textBox1->Location = System::Drawing::Point(96, 125);
			this->textBox1->Name = L"textBox1";
			this->textBox1->Size = System::Drawing::Size(100, 20);
			this->textBox1->TabIndex = 8;
			// 
			// label2
			// 
			this->label2->AutoSize = true;
			this->label2->Location = System::Drawing::Point(12, 128);
			this->label2->Name = L"label2";
			this->label2->Size = System::Drawing::Size(78, 13);
			this->label2->TabIndex = 9;
			this->label2->Text = L"Задержка(мс)";
			// 
			// checkBox2
			// 
			this->checkBox2->AutoSize = true;
			this->checkBox2->Location = System::Drawing::Point(267, 100);
			this->checkBox2->Name = L"checkBox2";
			this->checkBox2->Size = System::Drawing::Size(152, 17);
			this->checkBox2->TabIndex = 10;
			this->checkBox2->Text = L"Обрыв после 5 итераций";
			this->checkBox2->UseVisualStyleBackColor = true;
			this->checkBox2->CheckedChanged += gcnew System::EventHandler(this, &MyForm::checkBox2_CheckedChanged);
			// 
			// MyForm
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(480, 304);
			this->Controls->Add(this->checkBox2);
			this->Controls->Add(this->label2);
			this->Controls->Add(this->textBox1);
			this->Controls->Add(this->label1);
			this->Controls->Add(this->checkBox1);
			this->Controls->Add(this->OutputBox);
			this->Controls->Add(this->Thread1Button);
			this->Controls->Add(this->button1);
			this->Controls->Add(this->ExecuteButton);
			this->Controls->Add(this->ChooseFileButton);
			this->Controls->Add(this->FileBox);
			this->Name = L"MyForm";
			this->Text = L"System programming. Lab 1";
			this->FormClosing += gcnew System::Windows::Forms::FormClosingEventHandler(this, &MyForm::MyForm_FormClosing);
			this->Load += gcnew System::EventHandler(this, &MyForm::MyForm_Load);
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion



	private: System::Void MyForm_Load(System::Object^  sender, System::EventArgs^  e) {
		InitializeCriticalSection(&LPS);
		AllocConsole();
		freopen("CONOUT$", "w", stdout);
		openFileDialog1->Filter = "Executables | *.exe";
		TCHAR FilePath[256];
		GetCurrentDirectoryW(256,FilePath);
		std::wstring streng = CW2W(FilePath);
		System::String^ resultstr = msclr::interop::marshal_as<System::String^>(streng);
		openFileDialog1->InitialDirectory = resultstr;
	}
	private: System::Void ChooseFileButton_Click(System::Object^  sender, System::EventArgs^  e) {
		openFileDialog1->ShowDialog();
	}
	private: System::Void openFileDialog1_FileOk(System::Object^  sender, System::ComponentModel::CancelEventArgs^  e) {
		FileBox->Text = openFileDialog1->FileName;
	}


	private: System::Void ExecuteButton_Click(System::Object^  sender, System::EventArgs^  e) {
		msclr::interop::marshal_context mc;
		LPCSTR LPStr =  mc.marshal_as<LPCSTR>(FileBox->Text);
		WinExec(LPStr , SW_NORMAL);
	}


	private: System::Void MyForm_FormClosing(System::Object^  sender, System::Windows::Forms::FormClosingEventArgs^  e) {
		DeleteCriticalSection(&LPS);
		FreeConsole();
		Application::Exit();
	}
	private: System::Void button1_Click(System::Object^  sender, System::EventArgs^  e) {
		STARTUPINFO si;
		ZeroMemory(&si, sizeof(si));
		PROCESS_INFORMATION pi;
		msclr::interop::marshal_context mc;
		LPCWSTR LStr = mc.marshal_as<LPCWSTR>(FileBox->Text);
		CreateProcess(LStr, NULL, NULL, NULL, NULL, NULL, NULL, NULL, &si, &pi);
		//CloseHandle(pi.hThread);
		//CloseHandle(pi.hProcess);
	}

	private: System::Void Thread1Button_Click(System::Object^  sender, System::EventArgs^  e) {
		DWORD thrId[2];
		HANDLE ThrHandles[2];
		system("cls");
		ZZ = 100;
		if (!textBox1->Text->Equals(String::Empty))
			slptime = Convert::ToInt32(textBox1->Text);
		else
			slptime = 1000;
		if (checkBox1->Checked)
			Block = true;
		else
			Block = false;
		int *s1 = new int(0), *s2 = new int(1);
		ThrHandles[0] = CreateThread(NULL, 0, Func1, s1, 0, &thrId[0]);
		ThrHandles[1] = CreateThread(NULL, 0, Func2, s2, 0, &thrId[1]);
		DWORD RES = WaitForMultipleObjects(2, ThrHandles, true, INFINITE);
		OutputBox->Text = ZZ.ToString();
	}


private: System::Void checkBox2_CheckedChanged(System::Object^  sender, System::EventArgs^  e) {
	if (checkBox2->Checked) breakafter5 = true; else breakafter5 = false;
}
};
}
