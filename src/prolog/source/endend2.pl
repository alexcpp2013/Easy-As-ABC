:- include(transpose) .

third_end_view_puzzle :-

    length(Rows, 8),
    maplist(gen_row(8), Rows),
    transpose(Rows, Cols),

    maplist(fd_all_different, Rows),
    maplist(fd_all_different, Cols),

    Rows = [R1,R2,R3,R4,R5,R6,R7,R8],
    Cols = [C1,C2,C3,C4,C5,C6,C7,C8],

    start(R1, 5),  
  
    start(R2, 4),
    start(R3, 3),
    start(R4, 6),
    start(R5, 1),
    start(R7, 5),

    start(R8, 1),
    
    finish(R2, 6),
    finish(R3, 5),
    finish(R5, 5),
    finish(R6, 4),
    finish(R7, 3),

    start(C2, 1),
    start(C3, 6),
    start(C4, 2),
    start(C5, 3),
    start(C6, 2),
    
    finish(C1, 1),
    finish(C2, 3),
    finish(C3, 5),
    finish(C4, 4),
    finish(C5, 2),
    finish(C6, 3),
    finish(C7, 6),
    finish(C8, 6),

    maplist(fd_labeling, Rows),
    nl,
    maplist(out_row, Rows).

gen_row(N, Ls) :-
    length(Ls, N),
    fd_domain(Ls, 1, N).

out_row([]) :- nl.
out_row([H|T]) :-
    (H >= 7 -> write('-') ; write(H)),
    write(' '),
    out_row(T).

% constraint: Num is max third in that direction
start(Vars, Num) :-
    Vars = [A,B,C|_],
    A #= Num #\/ (A #>= 7 #/\ B #= Num) #\/ (A #>= 7 #/\ B #>= 7 #/\ C #= Num).

finish(Var, Num) :-
    reverse(Var, Rev), start(Rev, Num).