using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.Marks.MarkItem;
using CSharpScript.Game.Module.Map.Misc;
using CSharpScript.Game.Module.Teleport;
using CSharpScript.Game.Module.WorldMap;

namespace CSharpScript.Game.Module.Map.View.BaseMap.Assistant
{
	// Token: 0x020057F5 RID: 22517
	[NullableContext(1)]
	[Nullable(0)]
	public class MapSoundBoxSfxMgr
	{
		// Token: 0x0603947C RID: 234620 RVA: 0x00E88FC0 File Offset: 0x00E871C0
		public unsafe void OnMarkItemBecomeVisible(MarkItem markItem, Vector playerLocation)
		{
			if (markItem.MarkType != EMarkType.SoundBox && markItem.MarkType != EMarkType.CalmingWindBell)
			{
				return;
			}
			int markId = markItem.MarkId;
			if (ModelBase<TeleportModel>.Instance.IsTeleport)
			{
				ModelBase<WorldMapModel>.Instance.SetPlaySoundMarkSfxForbidden(markId, false);
				return;
			}
			double num = Vector.DistSquared(playerLocation, markItem.WorldPosition);
			if (num >= 434850976.0)
			{
				return;
			}
			bool flag = ModelBase<WorldMapModel>.Instance.IsSoundMarkSfxForbidden(markId);
			bool flag2 = ModelBase<WorldMapModel>.Instance.IsSoundMarkSfxCoolingDown(markId);
			ModelBase<WorldMapModel>.Instance.SetPlaySoundMarkSfxForbidden(markId, true);
			if (!flag && !flag2)
			{
				ELogAuthor author = ELogAuthor.LYX;
				string message = "[地图系统] 地图声匣子音效 播放 ->OnMarkItemBecomeVisible And PlaySfx";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("MarkId", markId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("distSquare", num);
				MapLogger.Debug(author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				ModelBase<WorldMapModel>.Instance.RecordPlaySoundMarkSfx(markId);
				Singleton<AudioSystem>.Instance.PostEvent("play_ui_find_shengxia");
			}
		}

		// Token: 0x0603947D RID: 234621 RVA: 0x00E890BC File Offset: 0x00E872BC
		public void OnMarkItemBecomeInvisible(MarkItem markItem)
		{
			int markId = markItem.MarkId;
			if (markItem.MarkType != EMarkType.SoundBox && markItem.MarkType != EMarkType.CalmingWindBell)
			{
				return;
			}
			ELogAuthor author = ELogAuthor.LYX;
			string message = "[地图系统] 地图声匣子音效 ->OnMarkItemBecomeInvisible";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("MarkId", markId);
			MapLogger.Debug(author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			ModelBase<WorldMapModel>.Instance.SetPlaySoundMarkSfxForbidden(markId, false);
		}

		// Token: 0x040208F6 RID: 133366
		public const float SOUND_MARK_INRANGE_DISTANCE_SQUARE = 434850980f;
	}
}
