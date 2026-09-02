using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A2A RID: 18986
	public class InputViewRecord
	{
		// Token: 0x060319DB RID: 203227 RVA: 0x00C5C8BC File Offset: 0x00C5AABC
		public int Add(EUiViewName viewName)
		{
			int num;
			if (this.ViewRecordMap.TryGetValue(viewName, out num))
			{
				int num2 = num + 1;
				this.ViewRecordMap[viewName] = num2;
				return num2;
			}
			this.ViewRecordMap[viewName] = 1;
			return 1;
		}

		// Token: 0x060319DC RID: 203228 RVA: 0x00C5C8FC File Offset: 0x00C5AAFC
		public int Remove(EUiViewName viewName)
		{
			int num;
			if (!this.ViewRecordMap.TryGetValue(viewName, out num))
			{
				return 0;
			}
			int num2 = num - 1;
			if (num2 > 0)
			{
				this.ViewRecordMap[viewName] = num2;
			}
			else
			{
				this.ViewRecordMap.Remove(viewName);
			}
			return num2;
		}

		// Token: 0x060319DD RID: 203229 RVA: 0x00C5C940 File Offset: 0x00C5AB40
		public bool Has(EUiViewName viewName)
		{
			int num;
			return this.ViewRecordMap.TryGetValue(viewName, out num) && num > 0;
		}

		// Token: 0x060319DE RID: 203230 RVA: 0x00C5C964 File Offset: 0x00C5AB64
		public bool HasAny()
		{
			using (Dictionary<EUiViewName, int>.ValueCollection.Enumerator enumerator = this.ViewRecordMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current > 0)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x060319DF RID: 203231 RVA: 0x00C5C9C0 File Offset: 0x00C5ABC0
		public int Size()
		{
			return this.ViewRecordMap.Count;
		}

		// Token: 0x060319E0 RID: 203232 RVA: 0x00C5C9CD File Offset: 0x00C5ABCD
		public void Clear()
		{
			this.ViewRecordMap.Clear();
		}

		// Token: 0x0401CE20 RID: 118304
		[Nullable(1)]
		private readonly Dictionary<EUiViewName, int> ViewRecordMap = new Dictionary<EUiViewName, int>();
	}
}
