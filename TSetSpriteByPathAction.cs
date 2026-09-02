using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002D71 RID: 11633
// (Invoke) Token: 0x060177AC RID: 96172
public delegate void TSetSpriteByPathAction(string path, UUISprite uiSprite, bool setSize, EUiViewName? syncLoadViewName = null, [Nullable(2)] Action<bool> callback = null);
