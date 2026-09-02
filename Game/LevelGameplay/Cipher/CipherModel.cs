using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.Cipher
{
	// Token: 0x02006F43 RID: 28483
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class CipherModel : ModelBase<CipherModel>
	{
		// Token: 0x06044F1E RID: 282398 RVA: 0x011F20B4 File Offset: 0x011F02B4
		public void InitCipherConfig(string inRow)
		{
			this.CipherId = inRow;
			if (this.GetCipherConfig(inRow) == null)
			{
				return;
			}
			if (this.Passwords == null)
			{
				this.Passwords = new List<int>();
			}
			if (this.CurPasswords == null)
			{
				this.CurPasswords = new List<int>();
			}
			if (this.CheckMap == null)
			{
				this.CheckMap = new Dictionary<int, bool>();
			}
			this.Passwords.Clear();
			this.CurPasswords.Clear();
			this.CheckMap.Clear();
			string text = this.GetCipherConfig(inRow).Value.Password.ToString().PadLeft(4, '0');
			for (int i = 0; i < 4; i++)
			{
				int num = UKismetStringLibrary.Conv_StringToInt(text[i].ToString());
				this.Passwords.Add(num);
				this.CurPasswords.Add(-1);
				this.CheckMap[num] = false;
			}
		}

		// Token: 0x06044F1F RID: 282399 RVA: 0x011F21AC File Offset: 0x011F03AC
		public CipherGameplay? GetCipherConfig(string inRow)
		{
			return ConfigCipherGameplayById.GetConfig(inRow, true);
		}

		// Token: 0x06044F20 RID: 282400 RVA: 0x011F21B8 File Offset: 0x011F03B8
		public bool IsPasswordCorrect()
		{
			for (int i = 0; i < 4; i++)
			{
				this.CheckMap[i] = (this.Passwords[i] == this.CurPasswords[i]);
			}
			for (int j = 0; j < 4; j++)
			{
				bool flag;
				if (!this.CheckMap.TryGetValue(j, out flag) || !flag)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06044F21 RID: 282401 RVA: 0x011F221C File Offset: 0x011F041C
		public bool GetCheckResultByIndex(int inValue)
		{
			bool flag;
			return this.CheckMap.TryGetValue(inValue, out flag) && flag;
		}

		// Token: 0x06044F22 RID: 282402 RVA: 0x011F223C File Offset: 0x011F043C
		public void SetCurPassword(int index, int value)
		{
			if (index >= this.CurPasswords.Count)
			{
				return;
			}
			this.CurPasswords[index] = value;
		}

		// Token: 0x06044F23 RID: 282403 RVA: 0x011F225A File Offset: 0x011F045A
		public string GetCipherConfigId()
		{
			return this.CipherId;
		}

		// Token: 0x04026717 RID: 157463
		private const int LEN = 4;

		// Token: 0x04026718 RID: 157464
		private const int INVLID = -1;

		// Token: 0x04026719 RID: 157465
		private string CipherId = "";

		// Token: 0x0402671A RID: 157466
		[Nullable(2)]
		private List<int> Passwords;

		// Token: 0x0402671B RID: 157467
		[Nullable(2)]
		private List<int> CurPasswords;

		// Token: 0x0402671C RID: 157468
		[Nullable(2)]
		private Dictionary<int, bool> CheckMap;
	}
}
