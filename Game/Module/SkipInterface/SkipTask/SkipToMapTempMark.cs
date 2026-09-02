using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Map;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.WorldMap;

namespace CSharpScript.Game.Module.SkipInterface.SkipTask
{
	// Token: 0x02004F4E RID: 20302
	public class SkipToMapTempMark : SkipTask
	{
		// Token: 0x060345FE RID: 214526 RVA: 0x00D1BC54 File Offset: 0x00D19E54
		protected override void OnRun([Nullable(new byte[]
		{
			1,
			2
		})] params object[] data)
		{
			string text = data[0] as string;
			int num = (text != null) ? int.Parse(text) : ((int)data[0]);
			MapMark? configMark = ConfigBase<MapConfig>.Instance.GetConfigMark(num);
			if (configMark == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.SkipInterface;
				ELogAuthor author = ELogAuthor.LRX;
				string message = "跳转失败，静态标记配置不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("mapMarkId", num);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				base.Finish();
				return;
			}
			ModelBase<MapModel>.Instance.CreateTempMapMark(num);
			WorldMapViewOpenParams data2 = new WorldMapViewOpenParams
			{
				MarkId = new int?(num),
				MarkType = (EMarkType)configMark.Value.ObjectType
			};
			ControllerBase<WorldMapController>.Instance.OpenView(EOpenMapType.Other, false, data2, null);
			base.Finish();
		}
	}
}
