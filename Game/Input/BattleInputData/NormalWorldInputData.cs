using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.InputSetting;

namespace CSharpScript.Game.Input.BattleInputData
{
	// Token: 0x02006FE1 RID: 28641
	[NullableContext(1)]
	[Nullable(0)]
	public class NormalWorldInputData : BattleInputData
	{
		// Token: 0x0604548D RID: 283789 RVA: 0x01218AA4 File Offset: 0x01216CA4
		public NormalWorldInputData()
		{
			Dictionary<string, EInputAction> dictionary = new Dictionary<string, EInputAction>();
			dictionary["跳跃"] = EInputAction.跳跃;
			dictionary["攀爬"] = EInputAction.攀爬;
			dictionary["走跑切换"] = EInputAction.走跑切换;
			dictionary["攻击"] = EInputAction.攻击;
			dictionary["闪避"] = EInputAction.闪避;
			dictionary["技能1"] = EInputAction.技能1;
			dictionary["幻象1"] = EInputAction.幻象1;
			dictionary["大招"] = EInputAction.大招;
			dictionary["幻象2"] = EInputAction.幻象2;
			dictionary["通用交互"] = EInputAction.通用交互;
			dictionary["锁定目标"] = EInputAction.锁定目标;
			dictionary["瞄准"] = EInputAction.瞄准;
			dictionary["下降"] = EInputAction.下降;
			this.ActionMap = dictionary;
			Dictionary<string, EInputAxis> dictionary2 = new Dictionary<string, EInputAxis>();
			dictionary2["LookUp"] = EInputAxis.LookUp;
			dictionary2["Turn"] = EInputAxis.Turn;
			dictionary2["MoveForward"] = EInputAxis.MoveForward;
			dictionary2["MoveRight"] = EInputAxis.MoveRight;
			dictionary2["Zoom"] = EInputAxis.Zoom;
			dictionary2["WheelAxis"] = EInputAxis.WheelAxis;
			this.AxisMap = dictionary2;
			base..ctor(EInputDataType.NormalWorld, EInputBindingType.Original);
		}

		// Token: 0x0604548E RID: 283790 RVA: 0x01218BFF File Offset: 0x01216DFF
		protected override Dictionary<string, EInputAction> OnGetActionMap()
		{
			return this.ActionMap;
		}

		// Token: 0x0604548F RID: 283791 RVA: 0x01218C07 File Offset: 0x01216E07
		protected override Dictionary<string, EInputAxis> OnGetAxisMap()
		{
			return this.AxisMap;
		}

		// Token: 0x04026A88 RID: 158344
		private readonly Dictionary<string, EInputAction> ActionMap;

		// Token: 0x04026A89 RID: 158345
		private readonly Dictionary<string, EInputAxis> AxisMap;
	}
}
