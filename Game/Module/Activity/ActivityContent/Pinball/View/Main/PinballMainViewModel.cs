using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Main
{
	// Token: 0x020065FE RID: 26110
	[NullableContext(2)]
	[Nullable(0)]
	public class PinballMainViewModel
	{
		// Token: 0x060413E6 RID: 267238 RVA: 0x010BCA16 File Offset: 0x010BAC16
		public PinballMainViewModel()
		{
			this.LevelDataList = new List<PinballLevelRecordData>();
		}

		// Token: 0x060413E7 RID: 267239 RVA: 0x010BCA29 File Offset: 0x010BAC29
		[NullableContext(1)]
		public void SetChapterData(PinballChapterData chapterData)
		{
			this.ChapterData = chapterData;
		}

		// Token: 0x060413E8 RID: 267240 RVA: 0x010BCA32 File Offset: 0x010BAC32
		public PinballChapterData GetChapterData()
		{
			return this.ChapterData;
		}

		// Token: 0x060413E9 RID: 267241 RVA: 0x010BCA3A File Offset: 0x010BAC3A
		[NullableContext(1)]
		public void SetLevelDataList(List<PinballLevelRecordData> levelDataList)
		{
			this.LevelDataList = levelDataList;
		}

		// Token: 0x060413EA RID: 267242 RVA: 0x010BCA43 File Offset: 0x010BAC43
		[NullableContext(1)]
		public List<PinballLevelRecordData> GetLevelDataList()
		{
			return this.LevelDataList;
		}

		// Token: 0x060413EB RID: 267243 RVA: 0x010BCA4B File Offset: 0x010BAC4B
		[NullableContext(1)]
		public void SetSelectLevelData(PinballLevelRecordData levelData)
		{
			this.SelectLevelData = levelData;
		}

		// Token: 0x060413EC RID: 267244 RVA: 0x010BCA54 File Offset: 0x010BAC54
		public void ClearSelectLevelData()
		{
			this.SelectLevelData = null;
		}

		// Token: 0x060413ED RID: 267245 RVA: 0x010BCA5D File Offset: 0x010BAC5D
		public PinballLevelRecordData GetSelectLevelData()
		{
			return this.SelectLevelData;
		}

		// Token: 0x060413EE RID: 267246 RVA: 0x010BCA65 File Offset: 0x010BAC65
		[NullableContext(1)]
		public void SetOverrideCloseFunc(Action func)
		{
			this.OverrideCloseFunc = func;
		}

		// Token: 0x060413EF RID: 267247 RVA: 0x010BCA6E File Offset: 0x010BAC6E
		public void ResetOverrideCloseFunc()
		{
			this.OverrideCloseFunc = null;
		}

		// Token: 0x060413F0 RID: 267248 RVA: 0x010BCA77 File Offset: 0x010BAC77
		public Action GetOverrideCloseFunc()
		{
			return this.OverrideCloseFunc;
		}

		// Token: 0x04024858 RID: 149592
		private PinballChapterData ChapterData;

		// Token: 0x04024859 RID: 149593
		[Nullable(1)]
		private List<PinballLevelRecordData> LevelDataList;

		// Token: 0x0402485A RID: 149594
		private PinballLevelRecordData SelectLevelData;

		// Token: 0x0402485B RID: 149595
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<string> ChangePlanetTexture;

		// Token: 0x0402485C RID: 149596
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<string> ChangePlanetMaskTexture;

		// Token: 0x0402485D RID: 149597
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<string> ChangePlanetSwitchTexture;

		// Token: 0x0402485E RID: 149598
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<string> SetViewTitle;

		// Token: 0x0402485F RID: 149599
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<string> SetViewIcon;

		// Token: 0x04024860 RID: 149600
		public Action<int> SetViewHelpId;

		// Token: 0x04024861 RID: 149601
		public Action<bool> SetViewHelpBtnActive;

		// Token: 0x04024862 RID: 149602
		private Action OverrideCloseFunc;
	}
}
