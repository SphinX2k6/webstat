using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Component;

namespace CSharpScript.Game.NewWorld.SceneItem.CurveControl
{
	// Token: 0x02004872 RID: 18546
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class CurveControlFactory : Singleton<CurveControlFactory>
	{
		// Token: 0x0603042E RID: 197678 RVA: 0x00BBD8F4 File Offset: 0x00BBBAF4
		[NullableContext(2)]
		public CurveControlBase CreateCurveControl(ECurveControlType? type)
		{
			if (type == null)
			{
				return null;
			}
			Func<CurveControlBase> func;
			if (this.CurveControlTypeMap.TryGetValue(type.Value, out func))
			{
				return func();
			}
			return null;
		}

		// Token: 0x0603042F RID: 197679 RVA: 0x00BBD92A File Offset: 0x00BBBB2A
		public CurveControlFactory()
		{
			Dictionary<ECurveControlType, Func<CurveControlBase>> dictionary = new Dictionary<ECurveControlType, Func<CurveControlBase>>();
			dictionary.Add(ECurveControlType.ChargeSlash, () => new ChargeSlashCurveControl());
			this.CurveControlTypeMap = dictionary;
			base..ctor();
		}

		// Token: 0x0401BB79 RID: 113529
		private readonly Dictionary<ECurveControlType, Func<CurveControlBase>> CurveControlTypeMap;
	}
}
