using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Menu.SubViews
{
	// Token: 0x02005779 RID: 22393
	[NullableContext(2)]
	[Nullable(0)]
	public class DeviceInfoItemData
	{
		// Token: 0x06038FE3 RID: 233443 RVA: 0x00E70F7B File Offset: 0x00E6F17B
		[NullableContext(1)]
		public DeviceInfoItemData(int id, string name, string lowText, [Nullable(new byte[]
		{
			1,
			0,
			1
		})] Func<ValueTuple<string, bool>> getInfoFunction)
		{
			this.Id = new int?(id);
			this.Name = name;
			this.LowText = lowText;
			this.GetInfoFunction = getInfoFunction;
		}

		// Token: 0x04020715 RID: 132885
		public int? Id;

		// Token: 0x04020716 RID: 132886
		public string Name;

		// Token: 0x04020717 RID: 132887
		public string LowText;

		// Token: 0x04020718 RID: 132888
		[Nullable(new byte[]
		{
			2,
			0,
			1
		})]
		public Func<ValueTuple<string, bool>> GetInfoFunction;
	}
}
